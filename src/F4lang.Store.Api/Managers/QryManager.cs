
using Generic.Cb.Abstractions;

namespace F4lang.Store.Api.Managers;

internal class QryManager : BaseManager, IQryManager
{
    private ICoreCbClient _cbClient; 

    public QryManager(ICoreCbClient cbClient) : base()
    {
        this._cbClient = cbClient ?? throw new NotImplementedException(nameof(cbClient));
    }

    public Task<IEnumerable<TResult>> ManageAsync<TResult>(IQry qry)
    {
        return this._cbClient.QueryScopeAsync<TResult>(qry.ScopeName, qry.Query);
    }
}
