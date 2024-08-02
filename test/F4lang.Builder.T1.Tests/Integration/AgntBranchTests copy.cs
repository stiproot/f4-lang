
// using F4lang.Core;
// using F4lang.Dapr.Infrastructure.Models;

// namespace F4lang.Builder.T1.Tests.Integration;

// public class AgntBranchTests
// {
// 	private static CancellationToken NewCancellationToken() => new CancellationToken();
// 	private readonly IStateManager _stateManager;

// 	public AgntBranchTests()
// 	{
// 		var serviceProvider = new ServiceProviderBuilder()
// 			.AddAll()
// 			.Build();

// 		this._stateManager = serviceProvider.GetService<IStateManager>() ?? throw new InvalidOperationException();
// 	}

// 	// [Fact]
// 	// public async Task IF_THEN_ELSE()
// 	// {
// 	// 	var cancellationToken = NewCancellationToken();

// 	// 	string qryTxt = @"""I would like you to write code for a Web API, that consists of a single endpoint, that accepts a POST request.
// 	// 	The endpoint will return a weather forecast.
// 	// 	This weather forecase lives in a data base, and so your code must query it, using Dapper.
// 	// 	Use SOLID principles.
// 	// 	""";

// 	// 	var qry = new AgntManagerQry { RawTxtQry = qryTxt };

// 	// 	var qryArg = new Msg<IAgntManagerQry>(qry, "qry");

// 	// 	var mn = this._stateManager
// 	// 		.Root<IAgntManagerInvoker>(
// 	// 			configureT =>
// 	// 				configureT
// 	// 					.SetId(AgntIds.CODER)
// 	// 					.MatchArg<IAgntMetadataHttpClient>(configure => configure.MatchArg(AgntIds.CODER))
// 	// 					.AddArg(qryArg)
// 	// 		)
// 	// 		.Then<IAgntManagerQryMapper>(configure => configure.RequireResult())
// 	// 		.Then<IAgntManagerInvoker>(
// 	// 			configureV =>
// 	// 				configureV
// 	// 					.SetId(AgntIds.CODE_VALIDATOR)
// 	// 					.MatchArg<IAgntMetadataHttpClient>(configure => configure.MatchArg(AgntIds.CODE_VALIDATOR))
// 	// 					.RequireResult()
// 	// 		)
// 	// 		.Then<ILogOutput>();

// 	// 	var n = mn.Build();

// 	// 	var msgs = await n.Resolve(cancellationToken);

// 	// 	Assert.Empty(msgs);
// 	// }

// 	[Fact]
// 	public async Task PAIR()
// 	{
// 		var cancellationToken = NewCancellationToken();

// 		string qryTxt = @"""I would like you to write code for a Web API, that consists of a single endpoint, that accepts a POST request.
// 		The endpoint will return a weather forecast.
// 		This weather forecase lives in a data base, and so your code must query it, using Dapper.
// 		Use SOLID principles.
// 		""";
// 		var qry = new AgntManagerQry { RawTxtQry = qryTxt };
// 		var qryArg = new Msg<IAgntManagerQry>(qry, "qry");

// 		// var mn = this._stateManager
// 		// 	.Pair<IAgntManagerInvoker, ICodeValidatorAgntActor>(
// 		// 		configureT => 
// 		// 			configureT
// 		// 				.RequireResult()
// 		// 				.AddArg(qryArg)
// 		// 				.MatchArg<IAgntMetadataHttpClient>(configure => configure.MatchArg(AgntIds.CODER))
// 		// 	)
// 		// 	.Then<ILogOutput>();

// 		var mn = this._stateManager
// 			.Pair<IAgntManagerInvoker, IAgntManagerInvoker>(
// 				configureT => 
// 					configureT
// 						.SetId(AgntIds.CODER)
// 						.MatchArg<IAgntMetadataHttpClient>(configure => configure.MatchArg(AgntIds.CODER))
// 						.AddArg(qryArg),
// 				configureV => 
// 					configureV
// 						.SetId(AgntIds.CODE_VALIDATOR)
// 						.MatchArg<IAgntMetadataHttpClient>(configure => configure.MatchArg(AgntIds.CODE_VALIDATOR))
// 						.RequireResult()
// 			)
// 			.Then<ILogOutput>();

// 		var n = mn.Build();

// 		var msgs = await n.Resolve(cancellationToken);

// 		Assert.Empty(msgs);
// 	}
// }