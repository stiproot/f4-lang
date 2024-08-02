
using Dapr.Actors.Runtime;
using Microsoft.Extensions.Logging;
using F4lang.Dapr.Infrastructure.Models;

namespace F4lang.Dapr.Actors;

[Actor(TypeName = nameof(AgntActorPoolResolverActor))]
public class AgntActorPoolResolverActor : Actor, IAgntActorPoolResolverActor
{
    private readonly ILogger<AgntActorPoolResolverActor> _logger;
    private readonly IActorProxyProvider _actorProxyProvider;
    private IEnumerable<IAgntActor>? _agntActors;

    public AgntActorPoolResolverActor(
        ActorHost host,
        ILogger<AgntActorPoolResolverActor> logger,
        IActorProxyProvider actorProxyProvider
    ) : base(host)  
    {
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this._actorProxyProvider = actorProxyProvider ?? throw new ArgumentNullException(nameof(actorProxyProvider));
    }

    public async Task InitPoolAsync(
        AgntActorPoolResolverReq req,
        CancellationToken cancellationToken = default
    )
    {
        this._logger.LogInformation($"Initializing agnt actor pool...");

        var inits = req.AgntIds.Select(this._actorProxyProvider.Provide);

        foreach (var a in inits) await a.InitAsync(cancellationToken);

        this._agntActors = inits;

        this._logger.LogInformation($"Agnt actor pool initialized.");
    }

    public async Task ResolvePoolAsync(
        AgntActorPoolResolverReq req,
        CancellationToken cancellationToken = default
    )
    {
        await this.InitPoolAsync(req, cancellationToken);

        this._logger.LogInformation($"Invoking first agnt actor in pool... agnt count: {this._agntActors!.Count()}");

        var qry = new AgntManagerQry { RawTxtQry = req.RawTxtQry };

        var msg = ActorMsgFactory.CreateCmd(qry);

        await this._agntActors!.First()!.ActAsync(msg);
    }
}