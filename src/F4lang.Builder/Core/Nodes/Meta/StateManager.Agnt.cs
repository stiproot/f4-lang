
namespace F4lang.Builder.Core;

public partial class StateManager : IStateManager
{
	public IStateManager AgntRoot<T>(Action<INodeConfigurationBuilder>? configure = null)
	{
		this.RootNode = this.StateNode = typeof(T).ToMetaNode(configure);

		return this;
	}

	public IStateManager Pair<T, V>(
		Action<INodeConfigurationBuilder>? configureT = null,
		Action<INodeConfigurationBuilder>? configureV = null,
		Action<IStateManager>? then = null,
		Action<IStateManager>? @else = null
	)
	{
		IMetaNode @from = typeof(T).ToMetaNode(configureT);
		IMetaNode @to = typeof(V).ToMetaNode(configureV, nodeType: MetaNodeTypes.Decision);

		@from.NodeEdge = new MetaNodeEdge { Next = @to };

		IMetaNode? levelTransition = this.NestedThen(then);

		if (levelTransition is not null)
		{
			@to.NodeEdge = new MetaNodeEdge { Next = levelTransition };
		}

		if (this.RootNode is null) this.RootNode = this.StateNode = @from;

		if (this.StateNode!.NodeEdge is null) this.StateNode.NodeEdge = new MetaNodeEdge { Next = @from };

		this.StateNode = @to;

		return this;
	}

	public IStateManager Decision<V>(
		Action<INodeConfigurationBuilder>? configureV = null,
		Action<IStateManager>? then = null,
		Action<IStateManager>? @else = null
	)
	{
		throw new NotImplementedException();
	}

	public IStateManager ContinuumPair<T, V>(
		Action<INodeConfigurationBuilder>? configureT = null,
		Action<INodeConfigurationBuilder>? configureV = null,
		Action<IStateManager>? then = null
	)
	{
		IMetaNode @from = typeof(T).ToMetaNode(configureT);

		var enrichedV = configureV.Enrich(c => c.Key(@from.NodeConfiguration.Id));
		IMetaNode @to = typeof(V).ToMetaNode(configureV, nodeType: MetaNodeTypes.Decision);

		@from.NodeEdge = new MetaNodeEdge { Next = @to };

		IMetaNode? levelTransition = this.NestedThen(then);

		if (levelTransition is not null)
		{
			@to.NodeEdge = new MetaNodeEdge { Next = levelTransition };
		}

		if (this.RootNode is null) this.RootNode = this.StateNode = @from;

		if (this.StateNode!.NodeEdge is null) this.StateNode.NodeEdge = new MetaNodeEdge { Next = @from };

		this.StateNode = @to;

		return this;
	}

	public IStateManager IsValid<T>(Action<INodeConfigurationBuilder>? configure = null)
	{
		var enriched = configure.Enrich(c => c.ControllerType(ControllerTypes.Decision));

		IMetaNode transition = typeof(T).ToMetaNode(enriched, MetaNodeTypes.Binary);

		if (this.RootNode is null)
		{
			this.RootNode = this.StateNode = transition;
			return this;
		}

		if (this.StateNode!.NodeEdge is null) this.StateNode.NodeEdge = new MetaNodeEdge();

		this.StateNode = this.StateNode.NodeEdge.Next = transition;

		return this;
	}
}