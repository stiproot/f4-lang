using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel.Memory;
using F4lang.Core.Models;

#pragma warning disable SKEXP0001, SKEXP0022, SKEXP0052, SKEXP0003

internal static class Sample2
{
    public static async Task RunAsync()
    {
        var provider = ServiceCollectionFactory.Create()
            .AddSlowCoreServices()
            .AddSlowConfiguration()
            .AddMappingRules()
            .BuildServiceProvider();

        var agntFactory = provider.GetService<IFactory<IAgntConfiguration, IAgnt>>()!;
        var mapper = provider.GetService<IObjMapper>()!;
        var memoryFactory = provider.GetService<IFactory<ISemanticTextMemory>>()!;
        var semanticTextMemory = memoryFactory.Create();
        // var documentLoader = provider.GetService<IDocumentLoader>()!;

        // var document = new DocumentModel 
        // { 
        //     CollectionName = "mermaid", 
        //     Id = "c4", 
        //     FilePath = "" 
        // };
        // await documentLoader.LoadAsync(new[] { document });

        // Mermaid examples:
        // - {{$c4_example}} {{recall $c4_example}}

        var configurationBuilder = new AgntConfigurationBuilder();
        var memory = new DefaultAgntMemory(semanticTextMemory, mapper);
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
        // var metadata = new AgntMetadataModel { SysPrompt = prompt, Fns = new[] { new AgntFn { FnName = "REQUEST_MORE_INFORMATION" } } };
        var metadata = new AgntMetadataModel { Fns = new[] { new AgntFn { FnName = "REQUEST_MORE_INFORMATION" } } };

        configurationBuilder.AddMemory(memory);
        configurationBuilder.AddMetadata(metadata);

        var configuration = configurationBuilder.Build();

        var agnt = agntFactory.Create(configuration).Configure();

        var qry = new AgntQry { RawTxtQry = @"
            Can you provide me with a sequence diagram for a system I am designing? 
            " };
        var result = await agnt.ProcessQryAsync(qry);
        Console.WriteLine(result.RawTxtRes);

        while (true)
        {
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            qry = new AgntQry { RawTxtQry = input };
            result = await agnt.ProcessQryAsync(qry);

            Console.WriteLine($"Agnt: {result.RawTxtRes}");
        }

    }
}