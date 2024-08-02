namespace F4lang.Builder.Core;

public class MetaNode(Type serviceType) : IMetaNode
{
    public Type ServiceType { get; init; } = serviceType;
    public MetaNodeTypes NodeType { get; set; } = MetaNodeTypes.Default;
	public IMetaNodeEdge? NodeEdge { get; set; }
	public INodeConfiguration NodeConfiguration { get; init; } = new NodeConfiguration();
}