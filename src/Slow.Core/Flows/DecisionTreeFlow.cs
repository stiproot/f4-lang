using Microsoft.SemanticKernel.Memory;
using Slow.Core.Extensions;
using PromiseTree.Abstractions;
using PromiseTree.Core;

#pragma warning disable SKEXP0011, SKEXP0022, SKEXP0052, SKEXP0003

public interface IFlow
{
    Task RunAsync(CancellationToken cancellationToken);
}

public interface IAgentManager
{
    Task ManageAsync(CancellationToken cancellationToken);
}

public sealed class AgentManager(IAgent agent) : IAgentManager
{
    public async Task ManageAsync(CancellationToken cancellationToken)
    {
        while(true)
        {
            Console.Write("Enter a query: ");
            var qry = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(qry))
            {
                break;
            }

            var res = await agent.ProcessQryAsync(new AgentQry { Qry = qry });

            Console.WriteLine(res.Res);
        }
    }
}

public sealed class DecisionTreeFlow(
    IStateManager stateManager,
    IObjMapper objMapper,
    IFactory<ISemanticTextMemory> semanticTextMemoryFactory
) : IFlow
{
    private readonly IStateManager _stateManager = stateManager ?? throw new ArgumentNullException(nameof(stateManager));
    private readonly IObjMapper _objMapper = objMapper ?? throw new ArgumentNullException(nameof(objMapper));
    private readonly IFactory<ISemanticTextMemory> _semanticTextMemoryFactory = semanticTextMemoryFactory ?? throw new ArgumentNullException(nameof(semanticTextMemoryFactory));

	public async Task RunAsync(CancellationToken cancellationToken)
	{
        var agentMetadata = new AgentMetadata { SysPrompt = "What does CQRS stand for?" };
        var agentMemory = this._semanticTextMemoryFactory.Create().ToAgentMemory(this._objMapper);

        IAgentConfiguration agentConfiguration = 
            new AgentConfigurationBuilder()
                .AddMetadata(agentMetadata)
                .AddMemory(agentMemory)
                .Build();

		var mn = this._stateManager
			.Root<IFactory<IAgentConfiguration, IAgent>>(configure => configure
                .MatchArg(agentConfiguration)
            )
			.Root<IAgent>(configure => configure
                .PreProcess(a => (a as IAgent)!.Configure())
                .MatchArg<IAgentQry>(new AgentQry { Qry = "What does CQRS stand for?" })
            );

		var n = mn.Build();

		var msgs = await n.Resolve(cancellationToken);
		var msg = msgs.First(); 
		var d = msg.Data<IAgentQryRes>(); 

        Console.WriteLine(d.Res);

		// var mn = this._stateManager
		// 	.Root<IY_OutConstBool_SyncService>()
		// 	.Key<IY_InBool_OutConstStr_AsyncService>(c => c.RequireResult())
		// 	.Hash<IY_AsyncService, IY_InBoolStr_OutConstInt_AsyncService>(
		// 		c => c.Key("key-a"),
		// 		c => c.MatchArg(true).MatchArg("<<arg>>").Key("<<str>>")
		// 	);


	}

}