
namespace F4lang.Builder.Core;

public class ServiceProviderAdaptor(
    IServiceProvider serviceProvider,
    IActorServiceProvider actorServiceProvider
    ) : IServiceProviderAdaptor
{
    private readonly IServiceProvider _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    private readonly IActorServiceProvider _actorServiceProvider = actorServiceProvider ?? throw new ArgumentNullException(nameof(actorServiceProvider));

    public object? GetService(Type serviceType)
    {
        if (serviceType.GetInterfaces().Any(i => i == typeof(IAgntActor))) return this._actorServiceProvider.GetService(serviceType);

        return this._serviceProvider.GetService(serviceType);
    }
}