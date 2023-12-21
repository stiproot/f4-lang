// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.SemanticKernel.Memory;
// using Slow.Core.Models;

// #pragma warning disable SKEXP0011, SKEXP0022, SKEXP0052, SKEXP0003

// var provider = ServiceCollectionFactory.Create()
//     .AddSlowServices()
//     .AddSlowConfiguration()
//     .AddMappingRules()
//     .BuildServiceProvider();

// var agentFactory = provider.GetService<IFactory<IAgentConfiguration, IAgent>>()!;
// var mapper = provider.GetService<IObjMapper>()!;
// var memoryFactory = provider.GetService<IFactory<ISemanticTextMemory>>()!;
// var semanticTextMemory = memoryFactory.Create();
// // var documentLoader = provider.GetService<IDocumentLoader>()!;

// // var document = new DocumentModel 
// // { 
// //     CollectionName = "mermaid", 
// //     Id = "c4", 
// //     FilePath = "/Users/simon.stipcich/code/lab/dotnet/slow/src/Slow.Console/.md/c4.min.md" 
// // };
// // await documentLoader.LoadAsync(new[] { document });

// // Mermaid examples:
// // - {{$c4_example}} {{recall $c4_example}}

// var configurationBuilder = new AgentConfigurationBuilder();
// var memory = new AgentMemory(semanticTextMemory, mapper);
// const string prompt = @"
//     You are a solution architect, who has a good understanding of the Mermaid UML scripting language.
//     You should not write any language or framework specific code; you designs should be generic.
//     Your job is to engage with a user and provide them with a Mermaid UML diagram that fulfills their design needs.
//     You only need to output Mermaid; do not worry about explaining your diagram.
//     If you are unsure of anything, ask the user for more information.
//     Use the example provided to you as you.

//     example:
//     {{$example}}
//     ---
//     If you need more information, here are some options available to you:
//     {{$options}}
//     ---
//     Chat History:
//     {{ConversationSummaryPlugin.SummarizeConversation $history}}
//     ---
//     User: {{$userInput}}
//     ";
// var metadata = new AgentMetadata { SysPrompt = prompt };

// configurationBuilder.AddMemory(memory);
// configurationBuilder.AddMetadata(metadata);

// var configuration = configurationBuilder.Build();

// var agent = agentFactory.Create(configuration).Configure();

// var qry = new AgentQry { Qry = @"
//     Can you provide me with a simple Mermaid C4 component diagram of a microservice architecture.
//     The services in the architecture are a UI web app and a web API that serves data." };
// var result = await agent.ProcessQryAsync(qry);
// Console.WriteLine(result.Res);

// while (true)
// {
//     var input = Console.ReadLine();

//     if (string.IsNullOrWhiteSpace(input))
//     {
//         break;
//     }

//     qry = new AgentQry { Qry = input };
//     result = await agent.ProcessQryAsync(qry);

//     Console.WriteLine($"Agent: {result.Res}");
// }
