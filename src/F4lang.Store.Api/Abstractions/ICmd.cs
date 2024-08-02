
namespace F4lang.Store.Api.Abstractions;

public interface ICmd
{
    string ScopeName { get; init; }
    string CollectionName { get; init; }
    string DocumentId { get; init; } 
    object Document { get; init; }
}