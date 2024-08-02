
// using F4lang.Dapr.Actors.Factories;

// public class AgntActorTests
// {
// 	private static CancellationToken NewCancellationToken() => new CancellationToken();
// 	private readonly IStateManager _stateManager;

// 	public AgntActorTests()
// 	{
// 		var serviceProvider = new ServiceProviderBuilder()
// 			.AddAll()
// 			.Build();

// 		this._stateManager = serviceProvider.GetService<IStateManager>() ?? throw new InvalidOperationException();
// 	}

// 	[Fact]
// 	public async Task THEN_THEN_THEN()
// 	{
// 		var cancellationToken = NewCancellationToken();

// 		string qryTxt = @"""I would like you to write code for a Web API, that consists of a single endpoint, that accepts a POST request.
// 		The endpoint will return a weather forecast.
// 		This weather forecase lives in a data base, and so your code must query it, using Dapper.
// 		Use SOLID principles.
// 		""";
// 		var actorCmd = ActorMsgFactory.CreateCmd(new AgntManagerQry { RawTxtQry = qryTxt });
// 		var cmdArg = new Msg<ActorCmd>(actorCmd, "cmd");

// 		var mn = this._stateManager
// 			.AgntRoot<ICoderAgntActor>(configure => configure.AddArg(cmdArg))
// 			.Then<IAgntManagerActorCmdMapper>(configure => configure.RequireResult())
// 			.Then<ICodeValidatorAgntActor>(configure => configure.RequireResult())
// 			.Then<ILogOutput>();

// 		var n = mn.Build();

// 		var msgs = await n.Resolve(cancellationToken);

// 		Assert.Empty(msgs);
// 	}
// }