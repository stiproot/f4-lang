using Microsoft.Extensions.DependencyInjection.Extensions;
using Generic.Cb.Extensions;
using F4lang.Core.Extensions;

namespace F4lang.Store.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSlowStoreApiServices(this IServiceCollection @this)
    {
        @this.TryAddSingleton<ICmdManager, CmdManager>();
        @this.TryAddSingleton<IQryManager, QryManager>();

        return @this;
    }

    // public static IServiceCollection AddDependentServices(this IServiceCollection @this,
    //     IConfiguration configuration
    // )
    // {
    //     return @this
    //         .AddCbServices(configuration);
    //         // .AddSlowCoreServices()
    //         // .AddSlowConfiguration()
    //         // .AddMappingRules()
    //         // .AddCachingServices();
    // }
}
