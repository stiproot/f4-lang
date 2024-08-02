
using F4lang.Dapr.Infrastructure.Models;

namespace F4lang.Dapr.Actors;

public interface IAgntActorPoolResolverActor : IActor
{
    Task InitPoolAsync(
        AgntActorPoolResolverReq req,
        CancellationToken cancellationToken = default
    );

    Task ResolvePoolAsync(
        AgntActorPoolResolverReq req,
        CancellationToken cancellationToken = default
    );
}