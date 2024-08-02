
using Dapr.Actors.Runtime;
using Microsoft.Extensions.Logging;

namespace F4lang.Dapr.Actors.Abstractions;

public abstract class BaseAgntActor : Actor
{
    protected readonly ILogger<BaseAgntActor> _Logger;
    protected readonly string _AgntId;
    protected readonly IAgntActorInit _AgntActorInit;
    protected IAgntManager? _AgntManager;

    public BaseAgntActor(
        ActorHost host,
        ILogger<BaseAgntActor> logger,
        IAgntActorInit agntActorInit,
        string agntId
    ) : base(host)
    {
        this._Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this._AgntActorInit = agntActorInit ?? throw new ArgumentNullException(nameof(agntActorInit));
        this._AgntId = agntId ?? throw new ArgumentNullException(nameof(agntId));
    }

    public virtual async Task<ActorRes> ActAsync(ActorCmd cmd)
    {
        // this._Logger.LogInformation($"BaseAgntActor.ActAsync: AgntId: {this._AgntId}: qry: {qry.RawTxtQry}");

        if (this._AgntManager is null) await this.InitAsync();

        var qry = cmd.Deserialize<AgntManagerQry>()!;

        var res = await this._AgntManager!.ManageAsync(qry);

        return ActorMsgFactory.CreateRes(res as AgntManagerQryRes);
    }

    public virtual async Task InitAsync(CancellationToken cancellationToken = default)
    {
        this._Logger.LogInformation($"BaseAgntActor.InitAsync: AgntId: {this._AgntId}");

        this._AgntManager = await this._AgntActorInit.InitAsync(this._AgntId, cancellationToken);
    }
}
