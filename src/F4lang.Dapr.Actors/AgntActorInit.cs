
using Microsoft.Extensions.Logging;

namespace F4lang.Dapr.Actors;

public class AgntActorInit : IAgntActorInit
{
    private readonly ILogger<AgntActorInit> _logger;
    protected readonly IAgntMemory _agntMemory;
    protected readonly IFactory<IAgntConfiguration, IAgnt> _agntFactory;
    protected readonly IFactory<IAgnt, IAgntManager> _agntManagerFactory;
    protected readonly IStoreApiGateway _StoreApiGateway;

    public AgntActorInit(
        ILogger<AgntActorInit> logger,
        IAgntMemory agntMemory,
        IFactory<IAgntConfiguration, IAgnt> agntFactory,
        IFactory<IAgnt, IAgntManager> agntManagerFactory,
        IStoreApiGateway storeApiGateway
    )
    {
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this._agntFactory = agntFactory ?? throw new ArgumentNullException(nameof(agntFactory));
        this._agntMemory = agntMemory ?? throw new ArgumentNullException(nameof(agntMemory));
        this._agntManagerFactory = agntManagerFactory ?? throw new ArgumentNullException(nameof(agntManagerFactory));
        this._StoreApiGateway = storeApiGateway ?? throw new ArgumentNullException(nameof(storeApiGateway));
    }

    public async Task<IAgntManager> InitAsync(
        string agntId,
        CancellationToken cancellationToken = default
    )
    {
        cancellationToken.ThrowIfCancellationRequested();

        var metadata = await this._StoreApiGateway.GetAgntMetadataAsync(agntId);

        var configBuilder = new AgntConfigurationBuilder()
            .AddMemory(this._agntMemory)
            .AddMetadata(metadata);

        this._logger.LogInformation("Building config.");
        var config = configBuilder.Build();

        this._logger.LogInformation("Creating and configuring agnt.");
        var agnt = this._agntFactory.Create(config).Configure();

        this._logger.LogInformation("Creating agnt manager.");
        var agntManager = this._agntManagerFactory.Create(agnt);

        this._logger.LogInformation("Returning agnt manager.");
        return agntManager;
    }
}
