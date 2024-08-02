
namespace F4lang.Store.Api.Abstractions;

public record GetAgntPoolQry : Qry
{
    public GetAgntPoolQry()
    {
        this.ScopeName = "defs";
    }
}