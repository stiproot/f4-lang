using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Plugins.Core;
using Microsoft.SemanticKernel.Plugins.Memory;
using Kernel = Microsoft.SemanticKernel.Kernel;

#pragma warning disable SKEXP0011, SKEXP0022, SKEXP0052, SKEXP0003, SKEXP0050

namespace Slow.Core;

public sealed class Agent(
    IAgentConfiguration configuration,
    Kernel kernel,
    IObjMapper mapper
) : BaseAgent(configuration, kernel, mapper), IAgent
{
    public IAgent Configure()
    {
        this._Kernel.ImportPluginFromObject(new TextMemoryPlugin(this._Configuration.Memory.Memory));
        this._Kernel.ImportPluginFromObject(new ConversationSummaryPlugin(), "ConversationSummaryPlugin");
        return this;
    }

    public async Task<IAgentQryRes> ProcessQryAsync(IAgentQry qry)
    {
        var memoryQry = this._Mapper.Map<IAgentQry, AgentMemoryQry>(qry);
        var memories = await this._Configuration.Memory.SearchAsync(memoryQry);

        Console.WriteLine("Memories:");
        foreach(var memory in memories)
        {
            Console.WriteLine(memory.Txt);
        }

        // todo: consolidate memories in context...

        var args = new KernelArguments
        {
            ["userInput"] = qry.Qry,
            ["history"] = string.Join("\n", this._ChatHistory),
            ["options"] = string.Join(",", this._Configuration.Metadata.Options),
            // ["context"] = string.Join("\n", memories.Select(m => m.Txt)), 
            // ["example"] = string.Join("\n", memories.Select(m => m.Txt)), 
            [TextMemoryPlugin.CollectionParam] = "mermaid",
            [TextMemoryPlugin.LimitParam] = "2",
            [TextMemoryPlugin.RelevanceParam] = "0.8",
        };

        var settings = new OpenAIPromptExecutionSettings { MaxTokens = 200, Temperature = 0.8 };

        var promptFn = this._Kernel.CreateFunctionFromPrompt(this._Configuration.Metadata.SysPrompt, settings);

        var fnRes = await promptFn.InvokeAsync(this._Kernel, args);

        var res = this._Mapper.Map<FunctionResult, AgentQryRes>(fnRes);

        this._ChatHistory.Add($"User: {qry.Qry}, ChatBot: {res.Res}");

        return res;
    }

    public async Task ProcessCmdAsync(IAgentCmd cmd)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
}