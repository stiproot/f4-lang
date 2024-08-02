
namespace F4lang.Dapr.Actors.Abstractions;

public interface IAgntActor : IActor
{
    Task<ActorRes> ActAsync(ActorCmd cmd);
    Task InitAsync(CancellationToken cancellationToken);
}