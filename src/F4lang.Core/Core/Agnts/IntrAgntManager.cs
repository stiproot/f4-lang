
// using Azure.AI.OpenAI;
// using Microsoft.DotNet.Interactive.AIUtilities;

// namespace F4lang.Core.Agnts;

// public class IntrAgntManager(
//     IAgnt agnt,
//     IFnHash fnHash,
//     IAgntEvtTransformer agntEvtTranformer
// ) : IIntrAgntManager
// {
//     private readonly IAgnt _agnt = agnt ?? throw new ArgumentNullException(nameof(agnt));
//     private readonly IFnHash _fnHash = fnHash ?? throw new ArgumentNullException(nameof(fnHash));
//     private readonly IAgntEvtTransformer _agntEvtTransformer = agntEvtTranformer ?? throw new ArgumentNullException(nameof(agntEvtTranformer));
//     private IAgntManagerHash? _agntManagerHash;
//     private IAgntCache? _agntCache;
//     private AgntChannel? _agntChannel;
//     private IDictionary<string, (Delegate del, GptFunction gptFn, FunctionDefinition fnDef)> _jitFnHash = new Dictionary<string, (Delegate, GptFunction, FunctionDefinition)>();
//     private IList<FunctionDefinition> _jitFnDefs = [];

//     public IAgntConfiguration AgntConfiguration => this._agnt.Configuration;
//     private readonly IAgntManagerQryRes AgntManagerQryRes = new AgntManagerQryRes();

//     public IAgntManager SetAgntManagerHash(IAgntManagerHash agntManagerHash)
//     {
//         this._agntManagerHash = agntManagerHash ?? throw new ArgumentNullException(nameof(agntManagerHash));
//         return this;
//     }

//     public IAgntManager SetCache(IAgntCache agntCache)
//     {
//         this._agntCache = agntCache ?? throw new ArgumentNullException(nameof(agntCache));
//         return this;
//     }

//     public IAgntManager SetChannel(AgntChannel agntChannel)
//     {
//         this._agntChannel = agntChannel;
//         return this;
//     }

//     private Task<IEnumerable<IAgntMemoryQryRes>> Remember(IAgntManagerQry qry)
//     {
//         // var memoryQry = new AgntMemoryQry { Qry = qry.Qry, Collection = this._agnt.Configuration.Metadata.Contexts.First().CollName };
//         var memoryQry = new AgntMemoryQry
//         {
//             Qry = this._agnt.Configuration.Metadata.Contexts.First().CollQryHint,
//             Collection = this._agnt.Configuration.Metadata.Contexts.First().CollName
//         };

//         return this._agnt.Configuration.Memory.SearchAsync(memoryQry);
//     }

//     public async Task<IAgntManagerQryRes> ManageAsync(
//         IAgntManagerQry qry,
//         CancellationToken cancellationToken = default
//     )
//     {
//         if (qry.JitFns.Any())
//         {
//             foreach (var jitFnBuilder in qry.JitFns)
//             {
//                 Delegate @delegate = jitFnBuilder.Build();
//                 GptFunction gptFn = GptFunction.Create(jitFnBuilder.Key, @delegate, enumsAsString: true);
//                 FunctionDefinition fnDef = FnDefBuilder.Build(gptFn);
//                 this._jitFnDefs.Add(fnDef);
//                 this._jitFnHash.Add(jitFnBuilder.Key, (@delegate, gptFn, fnDef));
//             }
//         }

//         if (this.AgntConfiguration.Metadata.Contexts.Any())
//         {
//             var memories = await this.Remember(qry);

//             foreach (var memory in memories)
//             {
//                 Console.WriteLine($"Memory: {memory.Txt}");
//                 this._agnt.Chat.AddContext(memory.Txt);
//             }
//         }

//         IAgntQryRes result = new EmptyAgntQryRes();

//         while (true)
//         {
//             Console.WriteLine($"AgntManager.ManageAsync::: JitFns: {qry.JitFns.Count}");

//             var agntQry = new AgntQry { QryUid = qry.QryUid, RawTxtQry = qry.RawTxtQry, JitFns = this._jitFnDefs };
//             result = await this._agnt.ProcessQryAsync(agntQry);
//             result.Log();
//             this.ManageAgntQryResAsync(result, agntQry);

//             if (result.Status is not AgntQryResStatus.PROCESSING)
//             {
//                 Console.WriteLine($"AgntManager.ManageAsync::: finished processing.");
//                 Console.WriteLine(this._agnt.Chat.Build());

//                 // return new AgntManagerQryRes 
//                 // { 
//                 //     AgntChat = this._agnt.Chat, 
//                 //     RawTxtRes = result.RawTxtRes 
//                 // };

//                 this.AgntManagerQryRes.AgntChat = this._agnt.Chat;
//                 this.AgntManagerQryRes.RawTxtRes = result.RawTxtRes;

//                 return this.AgntManagerQryRes;

//                 // return new AgntManagerQryRes { RawTxtRes = result.RawTxtRes };
//             }

//             Console.WriteLine($"AgntManager.ManageAsync::: still processing.");
//         }
//     }

//     private object? HandleFnInvocation(FunctionCall fnCall)
//     {
//         // if (fnCall.Name is FnNames.AGENT_QRY)
//         // {
//         //     var args = JsonSerializer.Deserialize<AgntQryFnParams>(fnCall.Arguments);
//         //     var agntQry = new AgntQry { Qry = args!.qry };
//         //     return this._agntManagerHash.Get(args.agntId).ManageAsync(agntQry).Result;
//         // }

//         if (!this._jitFnHash.TryGetValue(fnCall.Name, out var jitFn))
//         {
//             Console.WriteLine($"HandleFnInvocation(): {fnCall.Name} not found in jitFnHash");

//             var gptFn = this._fnHash.GetGptFn(fnCall.Name) ?? throw new InvalidOperationException($"Fn not found. {fnCall.Name}");
//             object? gptFnRes = gptFn.Execute(fnCall.Arguments);
//             Console.WriteLine($"HandleFnInvocation(): {fnCall.Name}({fnCall.Arguments})");

//             return gptFnRes;
//         }

//         var jitGptFn = jitFn.gptFn;
//         object? jitGptFnRes = jitGptFn.Execute(fnCall.Arguments);
//         Console.WriteLine($"(Jit) HandleFnInvocation(): {fnCall.Name}({fnCall.Arguments})");

//         return jitGptFnRes;
//     }

//     public void ManageAgntQryResAsync(
//         IAgntQryRes agntQryRes,
//         IAgntQry agntQry
//     )
//     {
//         var finishDetails = agntQryRes.ExtRes?.Value.Choices[0]?.FinishDetails;
//         var finishReason = agntQryRes.ExtRes?.Value.Choices[0]?.FinishReason;
//         var chatResponseMsg = agntQryRes.ExtRes?.Value.Choices[0]?.Message;
//         var fnCall = chatResponseMsg?.FunctionCall;

//         Console.WriteLine($"finishReason: {finishReason}");
//         Console.WriteLine($"finishDetails: {finishDetails}");
//         Console.WriteLine($"chatResponseMsg: {chatResponseMsg}");
//         Console.WriteLine($"fnCall: {chatResponseMsg}");

//         if (
//             finishReason.ToString() is "function_call" &&
//             chatResponseMsg?.FunctionCall is not null
//         )
//         {
//             var obj = this.HandleFnInvocation(fnCall!);

//             this._agnt.Chat.AddAgntChatHistory(new AgntChatHistory
//             {
//                 AgntChatType = AgntChatHistoryTypes.Agnt,
//                 Fn = fnCall!.Name,
//                 Args = fnCall.Arguments,
//                 FnRes = obj ?? "success",
//                 Agnt = agntQryRes.ExtRes!.Value.Choices[0]?.Message?.Content
//             });

//             if (fnCall.Name is "IS_VALID")
//             {
//                 this.AgntManagerQryRes.CallbackRes = obj;
//             }
//         }
//         else
//         {
//             this._agnt.Chat.AddAgntChatHistory(new AgntChatHistory
//             {
//                 AgntChatType = AgntChatHistoryTypes.Usr,
//                 Usr = agntQry.RawTxtQry,
//                 Agnt = chatResponseMsg?.Content
//             });
//         }

//         // this._agntChannel?.PushEvt(new AgntEvt { AgntChat = this._agnt.Chat, SrcAgnt = this._agnt.Configuration.Metadata.AgntId });

//         // function_call
//         if (finishReason?.ToString() is "stop")
//         {
//             agntQryRes.Status = AgntQryResStatus.COMPLETE;
//             this._agntCache?.SetAgntChat(this._agnt.Configuration.Metadata.AgntId, this._agnt.Chat);
//         }
//     }

//     public async Task HandleChannelEvt(IAgntEvt agntEvt)
//     {
//         // map agnt event to agnt qry...

//         var qry = await this._agntEvtTransformer.TransformAsync(agntEvt);

//         // await this._agnt.ProcessQryAsync(qry);
//     }
// }