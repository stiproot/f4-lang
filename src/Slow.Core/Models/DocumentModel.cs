namespace Slow.Core.Models;

public sealed record DocumentModel
{
    public string FilePath { get; init; } = string.Empty;
    public string CollectionName { get; init; } = string.Empty;
    public string Id { get; init; } = string.Empty;
}