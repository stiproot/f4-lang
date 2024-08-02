using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel.Memory;

#pragma warning disable SKEXP0001, SKEXP0022, SKEXP0052, SKEXP0003

internal static class WorkItemSample
{
    public static async Task RunAsync()
    {
        const bool loadDocs = true;
        if(loadDocs) await InitDocLoader.LoadAsync();

        var provider = ServiceCollectionFactory.Create()
            .AddSlowCoreServices()
            .AddSlowConfiguration()
            .AddMappingRules()
            .BuildServiceProvider();

        var agntFactory = provider.GetService<IFactory<IAgntConfiguration, IAgnt>>()!;
        var mapper = provider.GetService<IObjMapper>()!;
        var memoryFactory = provider.GetService<IFactory<ISemanticTextMemory>>()!;
        var semanticTextMemory = memoryFactory.Create();
        var agntMetadataLoader = provider.GetService<IAgntMetadataLoader>()!;
        var fileReader = provider.GetService<IFileReader>()!;

        var configurationBuilder = new AgntConfigurationBuilder();
        var memory = new DefaultAgntMemory(semanticTextMemory, mapper);

        // var metadata = await agntMetadataLoader.LoadAsync(".yml/architect_meta.yml");
        var metadata = await agntMetadataLoader.LoadJsnAsync(".json/wi_meta.json");
        Console.WriteLine(metadata.SysPrompt);

        configurationBuilder.AddMemory(memory);
        configurationBuilder.AddMetadata(metadata);

        var configuration = configurationBuilder.Build();

        var agnt = agntFactory.Create(configuration).Configure();

        var strBuilder = new StringBuilder();
        strBuilder.AppendLine("Translate the following yml work item structure into json.");
        strBuilder.AppendLine("");
        var yml = await fileReader.ReadAllTextAsync(".input/tasks.yml");
        strBuilder.AppendLine(yml);

        var qry = strBuilder.ToString();

        var agntQry = new AgntQry { RawTxtQry = qry };
        var result = await agnt.ProcessQryAsync(agntQry);
        Console.WriteLine(result.RawTxtRes);

        while (true)
        {
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            agntQry = new AgntQry { RawTxtQry = input };
            result = await agnt.ProcessQryAsync(agntQry);

            Console.WriteLine($"Agnt: {result.RawTxtRes}");
        }
    }
}
