namespace F4lang.Core.Models;

public sealed record AgntOptions
{
    public IEnumerable<AgntPoolMetadataAgntModel> Agnts { get; init; } = [];
}