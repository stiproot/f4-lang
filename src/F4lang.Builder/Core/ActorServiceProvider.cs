
namespace F4lang.Builder.Core;

public class ActorServiceProvider(
    ILogger<ActorServiceProvider> logger,
    IActorProxyProvider actorProxyProvider
) : IActorServiceProvider
{
    private readonly ILogger<ActorServiceProvider> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    private readonly IActorProxyProvider _actorProxyProvider = actorProxyProvider ?? throw new ArgumentNullException(nameof(actorProxyProvider));

    public object? GetService(Type serviceType) 
    {
        this._logger.LogInformation($"ActorServiceProvider.GetService: serviceType: {serviceType.FullName}");

        var actorId = Hashes.ActorTypeIdHash[serviceType];

        this._logger.LogInformation($"ActorServiceProvider.GetService: actorId: {actorId}");

        var service = this._actorProxyProvider.Provide(actorId);

        this._logger.LogInformation($"ActorServiceProvider.GetService: service: {service.GetType().FullName}");

        return service;
    }
}