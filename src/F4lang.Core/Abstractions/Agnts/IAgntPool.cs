namespace F4lang.Core.Abstractions;

public interface IAgntPool
{
    IAgntPool Init(IEnumerable<AgntMetadataModel> agntMetadataModels);
    Task ManageAsync(
        IAgntManagerQry qry,
        CancellationToken cancellationToken
    );
    IAgntManagerQryRes Result { get; }
}
