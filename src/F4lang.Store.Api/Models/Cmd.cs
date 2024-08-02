
namespace F4lang.Store.Api.Models;

public record Cmd : ICmd
{
    public string ScopeName { get; init; } = string.Empty;
    public string CollectionName { get; init; } = string.Empty;
    public string DocumentId { get; init; } = Guid.NewGuid().ToString();
    public object Document { get; init; } = string.Empty;
}

public record AddAgntMetadataCmd : Cmd
{
    public AddAgntMetadataCmd() : base()
    {
        this.ScopeName = "defs";
        this.CollectionName = "agnts";
    }
}

public record AddAgntPoolCmd : Cmd
{
    public AddAgntPoolCmd() : base()
    {
        this.ScopeName = "defs";
        this.CollectionName = "pools";
    }
}