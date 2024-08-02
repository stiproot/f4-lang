using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Generic.Caching.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCachingServices(this IServiceCollection @this)
    {
        @this.AddMemoryCache();
        @this.TryAddSingleton<ICache, Cache>();
        return @this;
    }
}