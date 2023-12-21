using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Generic.Extensions;
using Kernel = Microsoft.SemanticKernel.Kernel;
using Microsoft.SemanticKernel.Memory;
using AutoMapper;
using Slow.Core.Mappings;

#pragma warning disable SKEXP0011, SKEXP0022, SKEXP0052, SKEXP0003

namespace Slow.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSlowServices(this IServiceCollection @this)
    {
        @this.TryAddSingleton<IFactory<Kernel>, KernelFactory>();
        @this.TryAddSingleton<IFactory<IAgentConfiguration, IAgent>, AgentFactory>();
        @this.TryAddSingleton<IFactory<ISemanticTextMemory>, MemoryFactoryWithChromaStore>();
        @this.TryAddSingleton<IFileReader, FileReader>();
        @this.TryAddSingleton<IDocumentLoader, DocumentLoader>();
        @this.TryAddSingleton<IObjMapper, ObjMapper>();

        return @this;
    }

    public static IServiceCollection AddSlowConfiguration(this IServiceCollection @this)
    {
        var configuration = @this.AddConfigurations(configurations: new[] { "settings.json" });
        @this.ConfigureOptions<AgentOptions>(configuration, nameof(AgentOptions));
        @this.ConfigureOptions<ModelOptions>(configuration, nameof(ModelOptions));
        return @this;
    }

    public static IServiceCollection AddMappingRules(this IServiceCollection @this)
    {
        @this.TryAddSingleton(new MapperConfiguration(config => config.AddProfile<ModelProfile>()).CreateMapper());
        return @this;
    }
}