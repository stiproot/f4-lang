using System.Collections.Concurrent;

namespace F4lang.Core.Agnts;

public class AgntManagerHash : IAgntManagerHash
{
    private readonly IAgntMetadataLoader _agntMetadataLoader;
    private readonly IFactory<IAgntConfiguration, IAgnt> _agntFactory;
    private readonly IAgntMemory _agntMemory;
    private readonly IFactory<IAgnt, IAgntManager> _agntManagerFactory;
    private readonly ConcurrentDictionary<string, IAgntManager> _agntManagerHash = new();

    public AgntManagerHash(
        IAgntMetadataLoader agntMetadataLoader,
        IFactory<IAgntConfiguration, IAgnt> agntFactory,
        IAgntMemory agntMemory,
        IFactory<IAgnt, IAgntManager> agntManagerFactory
    )
    {
        this._agntMetadataLoader = agntMetadataLoader ?? throw new ArgumentNullException(nameof(agntMetadataLoader));
        this._agntFactory = agntFactory ?? throw new ArgumentNullException(nameof(agntFactory));
        this._agntMemory = agntMemory ?? throw new ArgumentNullException(nameof(agntMemory));
        this._agntManagerFactory = agntManagerFactory ?? throw new ArgumentNullException(nameof(agntManagerFactory));
    }

    public ConcurrentDictionary<string, IAgntManager> Hash => this._agntManagerHash;

    private async Task<IAgntManagerHash> CoreInitAsync(IEnumerable<AgntPoolMetadataAgntModel> agnts)
    {
        foreach(var agntInfo in agnts)
        {
            var metadata = await this._agntMetadataLoader.LoadJsnAsync(agntInfo.Metafile);

            var configBuilder = new AgntConfigurationBuilder()
                .AddMemory(this._agntMemory)
                .AddMetadata(metadata);

            var config = configBuilder.Build();
            var agnt = this._agntFactory.Create(config).Configure();
            var agntManager = this._agntManagerFactory.Create(agnt);

            this._agntManagerHash.TryAdd(agntInfo.AgntId, agntManager);
        }

        return this;
    }

    // public async Task<IAgntManagerHash> InitAsync(IOptions<AgntOptions> options)
    // {
    //     return await this.CoreInitAsync(options.Value.Agnts);
    // }

    // public async Task<IAgntManagerHash> InitAsync(AgntPoolMetadataModel agntPoolMetadata)
    // {
    //     return await this.CoreInitAsync(agntPoolMetadata.Agnts);
    // }

    public IAgntManagerHash Init(IEnumerable<AgntMetadataModel> agntMetadataModels)
    {
        foreach(var agntMetadata in agntMetadataModels)
        {
            var configBuilder = new AgntConfigurationBuilder()
                .AddMemory(this._agntMemory)
                .AddMetadata(agntMetadata);

            var config = configBuilder.Build();
            var agnt = this._agntFactory.Create(config).Configure();
            var agntManager = this._agntManagerFactory.Create(agnt);

            this._agntManagerHash.TryAdd(agntMetadata.AgntId, agntManager);
        }

        return this;
    }

    public IAgntManager Get(string agntId) => this._agntManagerHash[agntId];
}