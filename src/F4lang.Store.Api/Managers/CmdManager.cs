
using Generic.Cb.Abstractions;

namespace F4lang.Store.Api.Managers;

internal class CmdManager : BaseManager, ICmdManager
{
    private ICoreCbClient _cbClient; 

    public CmdManager(ICoreCbClient cbClient) : base()
    {
        this._cbClient = cbClient ?? throw new NotImplementedException(nameof(cbClient));
    }

    public Task ManageAsync(ICmd cmd)
    {
        return this._cbClient.UpsertDocumentAsync(
            cmd.ScopeName,
            cmd.CollectionName,
            cmd.DocumentId,
            cmd.Document
        );
    }
}
