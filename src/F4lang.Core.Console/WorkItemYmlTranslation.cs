using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel.Memory;
using Generic.Caching.Extensions;
using System.Text;

#pragma warning disable SKEXP0001, SKEXP0022, SKEXP0052, SKEXP0003

internal static class WorkItemYmlTranslation
{
    public static async Task RunAsync()
    {
        const bool loadDocs = false;
        if(loadDocs) await InitDocLoader.LoadAsync();

        var provider = ServiceCollectionFactory.Create()
            .AddSlowCoreServices()
            .AddCachingServices()
            .AddSlowConfiguration()
            .AddMappingRules()
            .BuildServiceProvider();

        var agntManagerFactory = provider.GetService<IAgntManagerFactory>()!;
        var agntFactory = provider.GetService<IFactory<IAgntConfiguration, IAgnt>>()!;
        var mapper = provider.GetService<IObjMapper>()!;
        var memoryFactory = provider.GetService<IFactory<ISemanticTextMemory>>()!;
        var semanticTextMemory = memoryFactory.Create();
        var agntMetadataLoader = provider.GetService<IAgntMetadataLoader>()!;
        var fileReader = provider.GetService<IFileReader>()!;

        var configurationBuilder = new AgntConfigurationBuilder();
        var memory = new DefaultAgntMemory(semanticTextMemory, mapper);

        Console.WriteLine("Loading metadata...");
        var metadata = await agntMetadataLoader.LoadJsnAsync("~/f4lang/src/F4lang.Core.Console/.metadata/wis/wi-yml-translator.meta.json");
        Console.WriteLine(metadata.SysPrompt);

        configurationBuilder.AddMemory(memory);
        configurationBuilder.AddMetadata(metadata);

        var configuration = configurationBuilder.Build();

        var agnt = agntFactory.Create(configuration).Configure();
        var agntManager = agntManagerFactory.Create(agnt, configuration);


        var strBuilder = new StringBuilder();
        strBuilder.AppendLine("Translate the following short-hand work item structure into correct yaml format.");
        strBuilder.AppendLine("Write the output to the following location: `~/f4lang/src/F4lang.Lab/formatted-wis.yml`");
        strBuilder.AppendLine();
        // ~/f4lang/src/F4lang.Core.Console/.input/wis/isa-krs.yml
        var yml = await fileReader.ReadAllTextAsync(".input/wis/isa-krs.yml");
        strBuilder.AppendLine(yml);

        var qryTxt = strBuilder.ToString();

        var qry = new AgntManagerQry 
        { 
            RawTxtQry = qryTxt
        };
        var result = await agntManager.ManageAsync(qry);
        Console.WriteLine(result.RawTxtRes);
    }
}
