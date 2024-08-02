
namespace F4lang.Core.Agnts;

public sealed class AgntManagerFactory(IFnHash fnHash) : IAgntManagerFactory
{
    private readonly IFnHash _fnHash = fnHash ?? throw new ArgumentNullException(nameof(fnHash));

    public IAgntManager Create(
        IAgnt agnt,
        IAgntConfiguration agntConfiguration
    ) 
        => new AgntManager(agnt, agntConfiguration, this._fnHash);
}