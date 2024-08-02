namespace F4lang.Builder.Abstractions;

public interface IInvokableNodeEdge : INodeEdge
{
	public INode? Edge1 { get; }
	public INode? Edge2 { get; }
}