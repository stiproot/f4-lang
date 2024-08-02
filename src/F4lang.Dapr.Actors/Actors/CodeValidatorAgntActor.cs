
using Dapr.Actors.Runtime;
using Microsoft.Extensions.Logging;
using F4lang.Dapr.Infrastructure.Models;

namespace F4lang.Dapr.Actors;

[Actor(TypeName = nameof(CodeValidatorAgntActor))]
public class CodeValidatorAgntActor(
    ActorHost host,
    ILogger<BaseAgntActor> logger,
    IAgntActorInit agntActorInit
    ) : BaseAgntActor(host, logger, agntActorInit, AgntIds.CODE_VALIDATOR), ICodeValidatorAgntActor
{
}