
namespace F4lang.Core.Abstractions;

public interface IAgntManagerInvoker
{
    Task<IAgntManagerQryRes> ManageAsync(
        AgntMetadataModel agntMetadataModel,
        IAgntManagerQry qry
    );
}