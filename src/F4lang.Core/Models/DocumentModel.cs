namespace F4lang.Core.Models;

public sealed record DocumentModel
{
    public string FilePath { get; init; } = string.Empty;
    public string CollectionName { get; init; } = string.Empty;
    public string Id { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}