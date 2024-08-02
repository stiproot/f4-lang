
namespace F4lang.Dapr.Actors.Abstractions;

public interface IStoreApiGateway
{
    Task<AgntMetadataModel> GetAgntMetadataAsync(
        string agntId,
        CancellationToken cancellationToken = default
    );
}