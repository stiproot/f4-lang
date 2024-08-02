
namespace F4lang.Core.Abstractions;

public interface IAgntManager
{
    IAgntConfiguration AgntConfiguration { get; }
    AgntChat AgntChat { get; }
    IAgntManager SetCache(IAgntCache agntCache);
    Task<IAgntManagerQryRes> ManageAsync(
        IAgntManagerQry qry,
        CancellationToken cancellationToken = default
    );
}