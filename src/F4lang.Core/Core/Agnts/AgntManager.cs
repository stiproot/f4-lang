
using Azure.AI.OpenAI;
using Microsoft.DotNet.Interactive.AIUtilities;

namespace F4lang.Core.Agnts;

public class AgntManager(
    IAgnt agnt,
    IAgntConfiguration agntConfiguration,
    IFnHash fnHash
) : IAgntManager
{
    private readonly IAgnt _agnt = agnt ?? throw new ArgumentNullException(nameof(agnt));
    private readonly IAgntConfiguration _agntConfiguration = agntConfiguration ?? throw new ArgumentNullException(nameof(agntConfiguration));
    private readonly IFnHash _fnHash = fnHash ?? throw new ArgumentNullException(nameof(fnHash));
    private readonly AgntChat _agntChat = new()
    { 
        SysPrompt = agntConfiguration.Metadata.SysPrompt,
        FnNames = agntConfiguration.Metadata.Fns.Select(f => $"{f.FnName}: {f.FnDesc}").ToArray(),
        AgntNames = agntConfiguration.Metadata.Agnts.Select(f => $"{f.AgntId}: {f.AgntDesc}").ToArray(),
        Collections = agntConfiguration.Metadata.Collections.Select(f => $"{f.CollName}: {f.CollDesc}").ToArray()
    };
    private readonly IAgntManagerQryResBuilder _agntManagerQryResBuilder = new AgntManagerQryResBuilder();

    private IAgntCache? _agntCache;
    private IDictionary<string, (Delegate del, GptFunction gptFn, FunctionDefinition fnDef)> _jitFnHash = new Dictionary<string, (Delegate, GptFunction, FunctionDefinition)>();
    private IList<FunctionDefinition> _jitFnDefs = [];

    public IAgntConfiguration AgntConfiguration => this._agntConfiguration;
    public AgntChat AgntChat => this._agntChat;


    public IAgntManager SetCache(IAgntCache agntCache)
    {
        this._agntCache = agntCache ?? throw new ArgumentNullException(nameof(agntCache));
        return this;
    }

    private Task<IEnumerable<IAgntMemoryQryRes>> Remember(IAgntManagerQry qry)
    {
        // var memoryQry = new AgntMemoryQry { Qry = qry.Qry, Collection = this._agnt.Configuration.Metadata.Contexts.First().CollName };
        var memoryQry = new AgntMemoryQry
        {
            Qry = this._agntConfiguration.Metadata.Contexts.First().CollQryHint,
            Collection = this._agntConfiguration.Metadata.Contexts.First().CollName
        };

        return this._agntConfiguration.Memory.SearchAsync(memoryQry);
    }

    public async Task<IAgntManagerQryRes> ManageAsync(
        IAgntManagerQry qry,
        CancellationToken cancellationToken = default
    )
    {
        if (qry.JitFns.Any())
        {
            foreach (var jitFnBuilder in qry.JitFns)
            {
                Delegate @delegate = jitFnBuilder.Build();
                GptFunction gptFn = GptFunction.Create(jitFnBuilder.Key, @delegate, enumsAsString: true);
                FunctionDefinition fnDef = FnDefBuilder.Build(gptFn);
                this._jitFnDefs.Add(fnDef);
                this._jitFnHash.Add(jitFnBuilder.Key, (@delegate, gptFn, fnDef));
            }
        }

        IEnumerable<FunctionDefinition> fnDefs = agntConfiguration.Metadata.Fns
            .Select(f => fnHash.GetFnDef(f.FnName))
            .ToArray();

        if (this._agntConfiguration.Metadata.Contexts.Any())
        {
            var memories = await this.Remember(qry);

            foreach (var memory in memories) this._agntChat.AddContext(memory.Txt);
        }

        IAgntQryRes result = new EmptyAgntQryRes();

        while (true)
        {
            var agntQry = new AgntQry { RawTxtQry = qry.RawTxtQry, AgntChat = this._agntChat, FnDefs = [.. fnDefs, ..this._jitFnDefs] };

            result = await this._agnt.ProcessQryAsync(agntQry);

            this.ManageAgntQryResAsync(result, agntQry);

            if (result.Status is not AgntQryResStatus.PROCESSING)
            {
                this._agntManagerQryResBuilder
                    .SetAgntChat(this._agntChat)
                    .SetRawTxtRes(result.RawTxtRes);

                return this._agntManagerQryResBuilder.Build();
            }
        }
    }

    private (object?, bool) HandleFnInvocation(FunctionCall fnCall)
    {
        string invocation = $"{fnCall.Name}({fnCall.Arguments})";

        if (this._agntChat.FnInvocations.Contains(invocation))
        {
            return (null, false);
        }

        if (!this._jitFnHash.TryGetValue(fnCall.Name, out var jitFn))
        {
            var gptFn = this._fnHash.GetGptFn(fnCall.Name) ?? throw new InvalidOperationException($"Fn not found. {fnCall.Name}");
            object? gptFnRes = gptFn.Execute(fnCall.Arguments);

            this._agntChat.FnInvocations.Add(invocation);

            return (gptFnRes, true);
        }
        else
        {
            var jitGptFn = jitFn.gptFn;
            object? jitGptFnRes = jitGptFn.Execute(fnCall.Arguments);

            this._agntChat.FnInvocations.Add($"{fnCall.Name}({fnCall.Arguments})");

            return (jitGptFnRes, true);
        }
    }

    public void ManageAgntQryResAsync(
        IAgntQryRes agntQryRes,
        IAgntQry agntQry
    )
    {
        // var finishDetails = agntQryRes.ExtRes?.Value.Choices[0]?.FinishDetails;
        var finishReason = agntQryRes.ExtRes?.Value.Choices[0]?.FinishReason;
        var chatResponseMsg = agntQryRes.ExtRes?.Value.Choices[0]?.Message;
        var fnCall = chatResponseMsg?.FunctionCall;

        // Console.WriteLine($"finishReason: {finishReason}");
        // Console.WriteLine($"finishDetails: {finishDetails}");
        // Console.WriteLine($"chatResponseMsg: {chatResponseMsg}");
        // Console.WriteLine($"fnCall: {chatResponseMsg}");

        if (finishReason?.ToString() is "stop")
        {
            agntQryRes.Status = AgntQryResStatus.COMPLETE;
            // this._agntCache?.SetAgntChat(this._agntConfiguration.Metadata.AgntId, this._agntChat);
            this._agntChat.AddAgntChatHistory(new AgntChatHistory
            {
                AgntChatType = AgntChatHistoryTypes.Usr,
                Usr = agntQry.RawTxtQry,
                Agnt = chatResponseMsg?.Content
            });
            return;
        }

        if (
            finishReason.ToString() is "function_call" &&
            chatResponseMsg?.FunctionCall is not null
        )
        {
            var (obj, invoked) = this.HandleFnInvocation(fnCall!);

            if (invoked is false) return;

            this._agntChat.AddAgntChatHistory(new AgntChatHistory
            {
                AgntChatType = AgntChatHistoryTypes.Agnt,
                Fn = fnCall!.Name,
                Args = fnCall.Arguments,
                FnRes = obj ?? "success",
                Agnt = agntQryRes.ExtRes!.Value.Choices[0]?.Message?.Content
            });

            if (fnCall.Name is "IS_VALID")
            {
                this._agntManagerQryResBuilder.SetCallbackRes(obj);
            }
        }
        else
        {
            this._agntChat.AddAgntChatHistory(new AgntChatHistory
            {
                AgntChatType = AgntChatHistoryTypes.Usr,
                Usr = agntQry.RawTxtQry,
                Agnt = chatResponseMsg?.Content
            });
        }
    }
}