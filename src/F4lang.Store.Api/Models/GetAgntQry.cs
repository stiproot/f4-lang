
namespace F4lang.Store.Api.Abstractions;

public record GetAgntQry : Qry
{
    public GetAgntQry()
    {
        this.ScopeName = "defs";
    }
}