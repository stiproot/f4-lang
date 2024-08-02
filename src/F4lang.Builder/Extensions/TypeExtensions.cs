
namespace F4lang.Builder.Extensions;

internal static class TypeExtensions
{
	public static IMetaNode ToMetaNode(this Type @this,
		Action<INodeConfigurationBuilder>? configure = null,
		MetaNodeTypes nodeType = MetaNodeTypes.Default
	)
	{
		var metaNode = new MetaNode(@this) { NodeType = nodeType };

		if (configure is not null)
		{
			configure(new NodeConfigurationBuilder(metaNode.NodeConfiguration, @this));
		}

		return metaNode;
	}

	public static IFn ToFn(this Type @this,
		IFnFactory fnFactory
	)
		=> fnFactory.Build(@this).SetServiceType(@this);

	public static IFn ToFn(this Type @this,
		IFnFactory fnFactory,
		string? nextParamName,
		Action<object>? preProcess = null
	)
		=> fnFactory.Build(@this, nextParamName: nextParamName, preProcess:preProcess).SetServiceType(@this);
}