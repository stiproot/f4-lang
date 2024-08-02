
string qryTxt = @"""I would like a Web API, that consists of a single endpoint, that accepts a POST request.
The endpoint will return a weather forecast, that is stored in a database.
Use SOLID principles.
The code must be written to the following file `~/f4lang/src/F4lang.Console/.output/weather.cs`.
""";

// var qry = new AgntQry { RawTxtQry = qryTxt };
// var actorType = nameof(CoderAgntActor);
var actorType = nameof(AgntActorPoolResolverActor);
// var actorId = new ActorId(AgntIds.CODER);
var actorId = new ActorId(AgntIds.ORCHESTRATOR);

// var proxy = ActorProxy.Create<ICoderAgntActor>(actorId, actorType);
var proxy = ActorProxy.Create<IAgntActorPoolResolverActor>(actorId, actorType);
var cancellationToken = new CancellationToken();

Console.WriteLine("Initializing proxy");
// await proxy.InitAsync(cancellationToken);

Console.WriteLine("Actioning proxy");
// var res = await proxy.ActAsync(qry, cancellationToken);

var req = new AgntActorPoolResolverReq 
{
    AgntIds = [ "promise-tree-dev" ], 
    LeaderAgntId = "promise-tree-dev",
    RawTxtQry = qryTxt 
};

await proxy.ResolvePoolAsync(req, cancellationToken);

// Console.WriteLine(res.RawTxtRes);