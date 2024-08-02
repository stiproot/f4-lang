namespace F4lang.Builder.Abstractions;

public interface IMultusNodeEdge : INodeEdge
{
	IList<INode> Edges { get; }
}