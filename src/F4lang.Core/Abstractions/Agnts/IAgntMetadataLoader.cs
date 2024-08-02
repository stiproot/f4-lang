namespace F4lang.Core.Abstractions;

public interface IAgntMetadataLoader
{
    Task<AgntMetadataModel> LoadYmlAsync(string filePath);
    Task<AgntMetadataModel> LoadJsnAsync(string filePath);
}