
namespace F4lang.Store.Api.Abstractions;

public record Qry : IQry
{
    public string ScopeName { get; init; } = string.Empty;
    public string Query { get; init; } = string.Empty;
}