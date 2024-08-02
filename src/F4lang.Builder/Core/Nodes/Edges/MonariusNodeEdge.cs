namespace F4lang.Builder.Core;

public class MonariusNodeEdge(INode edge) : IMonariusNodeEdge
{
	public NodeEdgeTypes NodeEdgeType => NodeEdgeTypes.Monarius;
    public INode Edge { get; internal set; } = edge;
}