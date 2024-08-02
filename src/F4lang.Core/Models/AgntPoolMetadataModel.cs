namespace F4lang.Core.Models;

public record AgntPoolMetadataModel
{
    public string AgntPoolId { get; init; } = string.Empty;
    public string LeaderAgntId { get; init; } = string.Empty;
    public IEnumerable<AgntPoolMetadataAgntModel> Agnts { get; init; } = [];
}