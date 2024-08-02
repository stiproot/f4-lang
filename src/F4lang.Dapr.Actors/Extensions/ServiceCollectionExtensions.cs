using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using F4lang.Core.Extensions;
using F4lang.Dapr.Actors.Gateways;
// using F4lang.Dapr.Actors.Mappings;

namespace F4lang.Dapr.Actors.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSlowDaprActorServices(this IServiceCollection @this,
        IConfiguration configuration
    )
    {
        @this.TryAddSingleton<IAgntActorInit, AgntActorInit>();
        @this.TryAddSingleton<IStoreApiGateway, StoreApiGateway>();
        @this.TryAddSingleton<IActorProxyProvider, ActorProxyProvider>();
        @this.TryAddSingleton<IAgntManagerActorCmdMapper, AgntManagerActorCmdMapper>();

        @this.AddActors();
        // @this.AddMappingRules();

        @this.AddAllSlowServices(configuration);

        return @this;
    }

    // public static IServiceCollection AddActorFnBuilders(this IServiceCollection @this)
    // {
    //     @this.TryAddSingleton<IFnBuilder, ActorInvokerFnBuilder>();
    //     return @this;
    // }

    public static IServiceCollection AddActors(this IServiceCollection @this)
    {
        @this.AddActors(options =>
        {
            // options.Actors.RegisterActor<CoderAgntActorBeta>();
            options.Actors.RegisterActor<CoderAgntActor>(nameof(CoderAgntActor));
            options.Actors.RegisterActor<CodeValidatorAgntActor>(nameof(CodeValidatorAgntActor));
            options.Actors.RegisterActor<AgntActorPoolResolverActor>(nameof(AgntActorPoolResolverActor));
        });

        return @this;
    }

    // public static IServiceCollection AddMappingRules(this IServiceCollection @this)
    // {
    //     @this.TryAddSingleton(new MapperConfiguration(config => config.AddProfile<ActorsModelProfile>()).CreateMapper());
    //     return @this;
    // }
}