
namespace F4lang.Dapr.Actors.Abstractions;

public interface IAgntManagerActorCmdMapper
{
    ActorCmd Map(ActorRes res);
}