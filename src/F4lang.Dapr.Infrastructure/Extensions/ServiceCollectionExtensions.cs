using Dapr.Actors.Runtime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace F4lang.Dapr.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSlowDaprInfrastructureServices(this IServiceCollection @this)
    {
        @this.TryAddScoped<IDaprAdaptor, DaprAdaptor>();
        return @this;
    }

    public static IServiceCollection AddActor<TActor>(this IServiceCollection @this) 
        where TActor : Actor
    {
        @this.AddActors(options =>
        {
            // Register actor types and configure actor settings
            options.Actors.RegisterActor<TActor>();
            
            // Configure default settings
            options.ActorIdleTimeout = TimeSpan.FromMinutes(10);
            options.ActorScanInterval = TimeSpan.FromSeconds(35);
            options.DrainOngoingCallTimeout = TimeSpan.FromSeconds(35);
            options.DrainRebalancedActors = true;
        });

        return @this;
    }
}