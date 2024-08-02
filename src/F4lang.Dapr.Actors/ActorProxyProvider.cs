
using Dapr.Actors.Client;
using Microsoft.Extensions.Logging;
using F4lang.Dapr.Infrastructure.Models;

namespace F4lang.Dapr.Actors;

public class ActorProxyProvider(
    ILogger<ActorProxyProvider> logger,
    IActorProxyFactory actorProxyFactory
) : IActorProxyProvider
{
    private readonly ILogger<ActorProxyProvider> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    private readonly IActorProxyFactory _actorProxyFactory = actorProxyFactory ?? throw new ArgumentNullException(nameof(actorProxyFactory));

    public IAgntActor Provide(string actorId)
    {
        this._logger.LogInformation($"ActorProxyProvider.Provide: actorId: {actorId}");

        return actorId switch
        {
            // AgntIds.CODER => this._actorProxyFactory.CreateActorProxy<ICoderAgntActor>(new ActorId(actorId), nameof(CoderAgntActor)),
            AgntIds.CODER => ActorProxy.Create<ICoderAgntActor>(new ActorId(actorId), nameof(CoderAgntActor)),
            AgntIds.CODE_VALIDATOR => ActorProxy.Create<ICodeValidatorAgntActor>(new ActorId(actorId), nameof(CodeValidatorAgntActor)),
            _ => throw new NotSupportedException()
        };
    }
}