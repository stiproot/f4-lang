
namespace F4lang.Dapr.Actors.Abstractions;

public interface IActorProxyProvider
{
    IAgntActor Provide(string actorId);
}