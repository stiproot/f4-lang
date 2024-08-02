using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Generic.Extensions;

namespace Generic.Cb.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCbServices(this IServiceCollection @this,
        IConfiguration configuration
    )
    {
        @this.ConfigureOptions<CouchbaseOptions>(configuration, nameof(CouchbaseOptions));
        @this.TryAddSingleton<IClusterFactory, ClusterFactory>();
        @this.TryAddSingleton<ICbClusterInit, CbClusterInit>();
        @this.TryAddSingleton<ICoreCbClient, CoreCbClient>();

        return @this;
    }
}
