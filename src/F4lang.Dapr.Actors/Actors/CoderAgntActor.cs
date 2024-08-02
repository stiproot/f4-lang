
using Dapr.Actors.Runtime;
using Microsoft.Extensions.Logging;
using F4lang.Dapr.Infrastructure.Models;

namespace F4lang.Dapr.Actors;

[Actor(TypeName = nameof(CoderAgntActor))]
public class CoderAgntActor(
    ActorHost host,
    ILogger<BaseAgntActor> logger,
    IAgntActorInit agntActorInit
    ) : BaseAgntActor(host, logger, agntActorInit, AgntIds.CODER), ICoderAgntActor
{
}