namespace F4lang.Core;

public class AgntPool : IAgntPool
{
    private readonly IAgntManagerHash _agntManagerHash;
    private IAgntManagerQryRes agntQryRes = new EmptyAgntManagerQryRes();

    public AgntPool(IAgntManagerHash agntManagerHash)
    {
        this._agntManagerHash = agntManagerHash ?? throw new ArgumentNullException(nameof(agntManagerHash));
    }

    public IAgntPool Init(IEnumerable<AgntMetadataModel> agntMetadataModels)
    {
        this._agntManagerHash.Init(agntMetadataModels);

        // foreach(var agntManager in this._agntManagerHash.Hash)
        // {
        //     agntManager.Value.SetAgntManagerHash(this._agntManagerHash);
        // }

        foreach(var agntManager in this._agntManagerHash.Hash)
        {
            var config = agntManager.Value.AgntConfiguration;
            if(config.Metadata.Subs.Any() is false)
            {
                continue;
            }

            var channel = new AgntChannel();
            foreach(var subs in config.Metadata.Subs)
            {
                var agnt = this._agntManagerHash.Get(subs.AgntId);
                // todo: add consolidate inter agnt manager with agnt pool...
                // channel.StateChanged += agnt.HandleChannelEvt;
            }

            // agntManager.Value.SetChannel(channel);
        }

        return this;
    }

    public async Task ManageAsync(
        IAgntManagerQry qry,
        CancellationToken cancellationToken
    )
    { 
        var agntPoolQry = qry as AgntPoolQry;
        this.agntQryRes = await this._agntManagerHash.Get(agntPoolQry!.LeadAgntId)
            .ManageAsync(qry, cancellationToken);
    }

    public IAgntManagerQryRes Result => this.agntQryRes;
}
