using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel.Memory;
using Slow.Core.Models;

#pragma warning disable SKEXP0011, SKEXP0022, SKEXP0052, SKEXP0003

var provider = ServiceCollectionFactory.Create()
    .AddSlowServices()
    .AddSlowConfiguration()
    .AddMappingRules()
    .BuildServiceProvider();

var agentFactory = provider.GetService<IFactory<IAgentConfiguration, IAgent>>()!;
var mapper = provider.GetService<IObjMapper>()!;
var memoryFactory = provider.GetService<IFactory<ISemanticTextMemory>>()!;
var semanticTextMemory = memoryFactory.Create();
// var documentLoader = provider.GetService<IDocumentLoader>()!;

// var document = new DocumentModel 
// { 
//     CollectionName = "mermaid", 
//     Id = "c4", 
//     FilePath = "/Users/simon.stipcich/code/lab/dotnet/slow/src/Slow.Console/.md/c4.min.md" 
// };
// await documentLoader.LoadAsync(new[] { document });

// Mermaid examples:
// - {{$c4_example}} {{recall $c4_example}}

var configurationBuilder = new AgentConfigurationBuilder();
var memory = new AgentMemory(semanticTextMemory, mapper);
const string prompt = @"
    You are an interactive solution architect.

    If you need more information, the following functions are available to you:
    {{$options}}
    ---
    Chat History:
    {{ConversationSummaryPlugin.SummarizeConversation $history}}
    ---
    User: {{$userInput}}
    ---
    If you would like to invoke an function, only return the function name, prefixed with option. Example: `function: REQUEST_MORE_INFORMATION`.
    ";
var metadata = new AgentMetadata { SysPrompt = prompt, Options = new[] { "REQUEST_MORE_INFORMATION" } };

configurationBuilder.AddMemory(memory);
configurationBuilder.AddMetadata(metadata);

var configuration = configurationBuilder.Build();

var agent = agentFactory.Create(configuration).Configure();

var qry = new AgentQry { Qry = @"
    Can you provide me with a sequence diagram for a system I am designing? 
    " };
var result = await agent.ProcessQryAsync(qry);
Console.WriteLine(result.Res);

while (true)
{
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        break;
    }

    qry = new AgentQry { Qry = input };
    result = await agent.ProcessQryAsync(qry);

    Console.WriteLine($"Agent: {result.Res}");
}
