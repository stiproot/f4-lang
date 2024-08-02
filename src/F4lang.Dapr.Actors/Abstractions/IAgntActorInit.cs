
namespace F4lang.Dapr.Actors.Abstractions;

public interface IAgntActorInit
{
    Task<IAgntManager> InitAsync(
        string agntId,
        CancellationToken cancellationToken = default
    );
}
