
namespace F4lang.Core.Abstractions;

public interface IAgntMetadataHttpClient
{
    Task<AgntMetadataModel> GetAgntMetadataAsync(string agntId);
}