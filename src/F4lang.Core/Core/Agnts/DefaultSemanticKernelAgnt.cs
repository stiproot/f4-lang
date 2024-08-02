// using Microsoft.SemanticKernel;
// using Microsoft.SemanticKernel.Connectors.OpenAI;
// using Microsoft.SemanticKernel.Plugins.Core;
// using Microsoft.SemanticKernel.Plugins.Memory;
// using F4lang.Core.Plugins;
// using Kernel = Microsoft.SemanticKernel.Kernel;

// #pragma warning disable SKEXP0001, SKEXP0022, SKEXP0052, SKEXP0003, SKEXP0050

// namespace F4lang.Core;

// public sealed class DefaultSemanticKernelAgnt(
//     IAgntConfiguration configuration,
//     Kernel kernel,
//     IObjMapper mapper
// ) : BaseSemanticKernelAgnt(kernel), IAgnt
// {
//     public IAgnt Configure()
//     {
//         this._Kernel.ImportPluginFromObject(new TextMemoryPlugin(this._Configuration.Memory.Memory));
//         this._Kernel.ImportPluginFromObject(new ConversationSummaryPlugin(), "ConversationSummaryPlugin");
//         this._Kernel.ImportPluginFromObject(new IoPlugin(), IoPlugin.PluginName);
//         return this;
//     }

//     private Task<IEnumerable<IAgntMemoryQryRes>> Remember(IAgntQry qry)
//     {
//         // var memoryQry = new AgntMemoryQry{ Qry = qry.Qry, Collection = this._Configuration.Metadata.Collection };
//         // return this._Configuration.Memory.SearchAsync(memoryQry);
//         throw new NotImplementedException();
//     }

//     public async Task<IAgntQryRes> ProcessQryAsync(IAgntQry qry)
//     {
//         // var memoryQry = this._Mapper.Map<IAgntQry, AgntMemoryQry>(qry);

//         var memories = await this.Remember(qry);

//         if(memories.Count() is 0) throw new InvalidOperationException("No memories found.");

//         foreach(var memory in memories)
//         {
//             Console.WriteLine("Memory:");
//             Console.WriteLine(memory.Txt);
//         }

//         var args = new KernelArguments
//         {
//             ["userInput"] = qry.RawTxtQry,
//             // ["history"] = this._Chat.Build(), // todo: check this...
//             ["fns"] = string.Join(",", this._Configuration.Metadata.Fns.Select(f => f.FnName)),
//             ["context"] = string.Join("\n", memories.Select(m => m.Txt)), 
//             // [TextMemoryPlugin.CollectionParam] = this._Configuration.Metadata.Collection,
//             [TextMemoryPlugin.LimitParam] = "2",
//             [TextMemoryPlugin.RelevanceParam] = "0.8",
//         };

//         var settings = new OpenAIPromptExecutionSettings 
//         { 
//             MaxTokens = this._Configuration.Metadata.MaxTokens,
//             Temperature = this._Configuration.Metadata.Temperature
//         };

//         var promptFn = this._Kernel.CreateFunctionFromPrompt(this._Configuration.Metadata.SysPrompt, settings);

//         // todo: fix this...

//         // var fnRes = await promptFn.InvokeAsync(this._Kernel, args);

//         // var res = this._Mapper.Map<FunctionResult, AgntQryRes>(fnRes);

//         // this._Chat.Add($"User: {qry.Qry}, ChatBot: {res.Res}");

//         // return res;

//         throw new NotImplementedException();
//     }
// }