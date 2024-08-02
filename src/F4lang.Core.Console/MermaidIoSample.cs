using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel.Memory;
using Generic.Caching.Extensions;

#pragma warning disable SKEXP0001, SKEXP0022, SKEXP0052, SKEXP0003

internal static class MermaidIoSample
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

        var configurationBuilder = new AgntConfigurationBuilder();
        var memory = new DefaultAgntMemory(semanticTextMemory, mapper);

        Console.WriteLine("Loading metadata...");
        var metadata = await agntMetadataLoader.LoadJsnAsync("~/f4lang/src/F4lang.Core.Console/.metadata/pools/mermaid/mermaid-architect.meta.json");
        Console.WriteLine(metadata.SysPrompt);

        configurationBuilder.AddMemory(memory);
        configurationBuilder.AddMetadata(metadata);

        var configuration = configurationBuilder.Build();

        var agnt = agntFactory.Create(configuration).Configure();
        var agntManager = agntManagerFactory.Create(agnt, configuration);

        var qry = new AgntManagerQry 
        { 
            RawTxtQry = @"Can you provide me with a simple Mermaid C4 component diagram of a microservice architecture.
                The services in the architecture are a UI web app and a web API that serves data.
                Write the output to the following file `~/f4lang/src/F4lang.Lab/mermaid_001.md`",
        };
        var result = await agntManager.ManageAsync(qry);
        Console.WriteLine(result.RawTxtRes);
    }
}
