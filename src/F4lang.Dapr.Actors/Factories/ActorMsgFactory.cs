
namespace F4lang.Dapr.Actors.Factories;

public static class ActorMsgFactory
{
    public static ActorCmd CreateCmd<T>(T data) => new ActorCmd().Init(data);
    public static ActorRes CreateRes<T>(T data) => new ActorRes().Init(data);
}