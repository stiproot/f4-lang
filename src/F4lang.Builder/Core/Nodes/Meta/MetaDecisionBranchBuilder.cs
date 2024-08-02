
namespace F4lang.Builder.Abstractions;

public class MetaDecisionBranchBuilder(
    INodeBuilderFactory nodeBuilderFactory,
    IFnFactory fnFactory,
    ILogger? logger = null,
    IWorkflowContext? workflowContext = null
    ) : CoreBranchBuilder(
		nodeBuilderFactory,
		fnFactory,
		logger,
		workflowContext
	), IMetaBranchBuilder
{
	public virtual IMetaBranchBuilder Validate(IMetaNode metaNode)
	{
		metaNode.ThrowIfNull();

		if (metaNode.NodeType is not MetaNodeTypes.Decision) throw new InvalidOperationException("Invalid meta node type.");

		metaNode.NodeEdge.ThrowIfNull();

		if (metaNode.NodeEdge!.Next is null) throw new InvalidOperationException();

		return this;
	}

	public INode Build(
		IMetaNodeMapper metaNodeMapper,
		IMetaNode metaNode
	)
	{
		this.Validate(metaNode);

		return this.BuildDecision(metaNodeMapper, metaNode);
	}

	protected INode BuildDecision(
		IMetaNodeMapper metaNodeMapper,
		IMetaNode? mn
	)
	{
		if (mn is null) throw new InvalidOperationException("Metanode is null.");

		INode then = metaNodeMapper.Map(mn.NodeEdge!.Next!);

		InjectableDecisionFlowControlFnBuilder decisionFlowControl = new(then);

		// Key represents the id of the node to "route" to.
		if (mn.NodeConfiguration.Key is not null)
		{
			INodeConfiguration resToReqMapperConfig = new NodeConfigurationBuilder(typeof(IAgntManagerQryMapper))
				.RequireResult()
				.AddContext(mn.NodeConfiguration.WorkflowContext)
				.Configuration();
			IFn resToReqMapperFn = typeof(IAgntManagerQryMapper).ToFn(this._FnFactory);
			INodeBuilder resToReqMapperNb = this._NodeBuilderFactory
				.Create()
				.Configure(resToReqMapperConfig)
				.AddFn(resToReqMapperFn)
				.AddNodeEdge(NodeEdgeFactory.CreateContextus(mn.NodeConfiguration.Key ?? throw new InvalidOperationException("NodeConfiguration.Key not found")));
			INode resToReqMapperNode = resToReqMapperNb.Build();

			decisionFlowControl.SetFalse(resToReqMapperNode);
		}

		mn.NodeConfiguration.ArgEnrichers.Add((typeof(AgntManagerQry), (arg) =>
		{
			var data = (arg as BaseMsg<AgntManagerQry>)!.Data<AgntManagerQry>();
			data.JitFns.Add(decisionFlowControl);
		}));

		INodeConfiguration resolverConfig = new NodeConfigurationBuilder(typeof(IAgntDecisionNodeResolver))
			.RequireResult()
			.Configuration();
		IFn resolverFn = typeof(IAgntDecisionNodeResolver).ToFn(this._FnFactory);
		INodeBuilder resolverNb = this._NodeBuilderFactory
			.Create()
			.Configure(resolverConfig)
			.AddFn(resolverFn);
		INode resolverNode = resolverNb.Build();

		INodeEdge edge = NodeEdgeFactory.CreateMonarius(resolverNode);

		IFn fn = mn.ServiceType.ToFn(this._FnFactory, mn.NodeConfiguration.NextParamName, mn.NodeConfiguration.PreProcess);
		IList<INode> promisedArgs = mn.NodeConfiguration.MetaPromisedArgs.Select(p => metaNodeMapper.Map(p)).ToList();
		mn.NodeConfiguration.PromisedArgs.AddRange(promisedArgs);
		mn.NodeConfiguration.RequiresResult = true;

		INodeBuilder nb = this._NodeBuilderFactory
			.Create()
			.Configure(mn.NodeConfiguration)
			.AddFn(fn)
			.AddNodeEdge(edge);

		// MAPPER...
		INodeConfiguration mapperConfig = new NodeConfigurationBuilder(typeof(IAgntManagerQryMapper))
			.RequireResult()
			.Configuration();
		IFn mapperFn = typeof(IAgntManagerQryMapper).ToFn(this._FnFactory);
		INodeBuilder mapperNb = this._NodeBuilderFactory
			.Create()
			.Configure(mapperConfig)
			.AddFn(mapperFn);
		INodeEdge mapperEdge = NodeEdgeFactory.CreateMonarius(nb.Build());
		mapperNb.AddNodeEdge(mapperEdge);

		INode node = mapperNb.Build();

		return node;
	}
}
