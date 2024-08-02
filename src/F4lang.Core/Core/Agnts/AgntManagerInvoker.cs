
namespace F4lang.Core.Agnts;

public class AgntManagerInvoker(
    IAgntManagerFactory agntManagerFactory,
    IFactory<IAgntConfiguration, IAgnt> agntFactory,
    IAgntMemory agntMemory
    ) : IAgntManagerInvoker
{
    private readonly IAgntManagerFactory _agntManagerFactory = agntManagerFactory ?? throw new ArgumentNullException(nameof(agntManagerFactory));
    private readonly IFactory<IAgntConfiguration, IAgnt> _agntFactory = agntFactory ?? throw new ArgumentNullException(nameof(agntFactory));
    private readonly IAgntMemory _agntMemory = agntMemory ?? throw new ArgumentNullException(nameof(agntMemory));

    public async Task<IAgntManagerQryRes> ManageAsync(
        AgntMetadataModel agntMetadataModel,
        IAgntManagerQry qry
    )
    { 
        var agntManager = this.InitAgnt(agntMetadataModel);
        return await agntManager.ManageAsync(qry);
    }

    public IAgntManager InitAgnt(AgntMetadataModel agntMetadataModel)
    {
        var configBuilder = new AgntConfigurationBuilder()
            .AddMemory(this._agntMemory)
            .AddMetadata(agntMetadataModel);

        var config = configBuilder.Build();
        var agnt = this._agntFactory.Create(config).Configure();
        var agntManager = this._agntManagerFactory.Create(agnt, config);

        return agntManager;
    }
}
