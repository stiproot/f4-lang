namespace F4lang.Core.Models;

public sealed record AgntPoolOptions
{
    public IEnumerable<AgntPoolMetadataModel> AgntPools { get; init; } = Array.Empty<AgntPoolMetadataModel>();
}