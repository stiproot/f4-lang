
namespace F4lang.Store.Api.Abstractions;

public interface IQry
{
    string ScopeName { get; init; }
    string Query { get; init; }
}