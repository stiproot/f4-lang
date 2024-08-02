using F4lang.Core.Mappings;
using Generic.Extensions;
using Generic.Caching.Extensions;
using Generic.FileParsers.Abstractions;
using Generic.FileParsers;
using AutoMapper;
using Azure.AI.OpenAI;
using Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Kernel = Microsoft.SemanticKernel.Kernel;
using Microsoft.SemanticKernel.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Connectors.Chroma;

#pragma warning disable SKEXP0001, SKEXP0022, SKEXP0052, SKEXP0003, SKEXP0010, SKEXP0020
namespace F4lang.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAllSlowServices(this IServiceCollection @this,
        IConfiguration configuration
    )
    {
        return @this
            .AddSlowCoreServices()
            .AddSlowConfiguration()
            .AddMappingRules()
            .AddOpenAIClient(configuration)
            .AddDefaultSemanticTextMemory(configuration)
            .AddCachingServices();
    }

    public static IServiceCollection AddSlowCoreServices(this IServiceCollection @this)
    {
        @this.TryAddSingleton<IFileReader, FileReader>();
        @this.TryAddSingleton<IFileWriter, FileWriter>();

        @this.TryAddSingleton<IFactory<Kernel>, KernelFactory>();
        @this.TryAddSingleton<IFactory<IAgntConfiguration, IAgnt>, AgntFactory>();
        @this.TryAddSingleton<IFactory<ISemanticTextMemory>, MemoryFactoryWithChromaStore>();
        @this.TryAddSingleton<IAgntManagerFactory, AgntManagerFactory>();

        @this.TryAddSingleton<IDocumentLoader, DocumentLoader>();
        @this.TryAddSingleton<IAgntMetadataLoader, AgntMetadataLoader>();
        @this.TryAddSingleton<IObjMapper, ObjMapper>();

        @this.TryAddSingleton<IYmlSerializer, YmlSerializer>();
        @this.TryAddSingleton<IJsnSerializer, JsnSerializer>();
        @this.TryAddSingleton<ICsValidator, CsValidator>(); 

        @this.TryAddSingleton<IAgntMemory, DefaultAgntMemory>();
        @this.TryAddSingleton<IAgntPool, AgntPool>();
        @this.TryAddSingleton<IAgntManagerHash, AgntManagerHash>();
        @this.TryAddSingleton<IAgntCache, AgntCache>();
        @this.TryAddSingleton<IAgntManagerInvoker, AgntManagerInvoker>();
        @this.TryAddSingleton<IAgntMetadataHttpClient, AgntMetadataHttpClient>();

        @this.TryAddSingleton<IAgntManagerQryMapper, AgntManagerQryMapper>();

        @this.AddSlowFnBuilders();

        return @this;
    }

    public static IServiceCollection AddSlowFnBuilders(this IServiceCollection @this)
    {
        @this.TryAddSingleton<IFnHash, FnHash>();
        @this.TryAddSingleton<ILazyFnHashInit, LazyFnHashInit>();
        @this.AddSingleton<IFnBuilder, IoWriteDiskFnBuilder>();
        @this.AddSingleton<IFnBuilder, IoReadDiskFnBuilder>();
        @this.AddSingleton<IFnBuilder, IoReadChromaFnBuilder>();
        @this.AddSingleton<IFnBuilder, IoReadConsoleFnBuilder>();
        @this.AddSingleton<IFnBuilder, ShellCmdFnBuilder>();
        @this.AddSingleton<IFnBuilder, AgntQryFnBuilder>();
        @this.AddSingleton<IFnBuilder, IoReadAgntCacheFnBuilder>();

        return @this;
    }

    public static IServiceCollection AddSlowConfiguration(this IServiceCollection @this)
    {
        // var configuration = @this.AddConfigurations(configurations: new[] { "settings.json" });
        var configuration = @this.AddConfigurations();
        // @this.ConfigureOptions<AgntOptions>(configuration, nameof(AgntOptions));
        @this.ConfigureOptions<ModelOptions>(configuration, nameof(ModelOptions));
        @this.ConfigureOptions<AgntPoolOptions>(configuration, nameof(AgntPoolOptions));
        @this.AddOpenAIClient(configuration);
        @this.AddDefaultSemanticTextMemory(configuration);
        return @this;
    }

    public static IServiceCollection AddMappingRules(this IServiceCollection @this)
    {
        @this.TryAddSingleton(new MapperConfiguration(config => config.AddProfile<ModelProfile>()).CreateMapper());
        return @this;
    }

    public static IServiceCollection AddOpenAIClient(this IServiceCollection @this,
        IConfiguration configuration
    )
    {
        var cred = new AzureKeyCredential(configuration["modelOptions:apiKey"]!);
        var client = new OpenAIClient(new Uri(configuration["modelOptions:endpoint"]!), cred);
        @this.TryAddSingleton<OpenAIClient>(client);
        return @this;
    }

    public static IServiceCollection AddDefaultSemanticTextMemory(this IServiceCollection @this,
        IConfiguration configuration
    )
    {
        var memoryBuilder = new MemoryBuilder();

        var handler = new HttpClientHandler { CheckCertificateRevocationList = false };
        var client = new HttpClient(handler);

        memoryBuilder.WithAzureOpenAITextEmbeddingGeneration(
            configuration["memoryOptions:default:embedding"]!, 
            configuration["modelOptions:endpoint"]!, 
            configuration["modelOptions:apiKey"]!, 
            configuration["memoryOptions:default:modelId"]!,
            client
        );

        var chromaMemoryStore = new ChromaMemoryStore(configuration["memoryOptions:default:chromaEndpoint"]!);

        memoryBuilder.WithMemoryStore(chromaMemoryStore);

        var memory = memoryBuilder.Build();

        @this.TryAddSingleton<ISemanticTextMemory>(memory);

        return @this;
    }
}