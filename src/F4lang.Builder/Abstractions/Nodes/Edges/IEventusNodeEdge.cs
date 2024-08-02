namespace F4lang.Builder.Abstractions;

public interface IEventusNodeEdge : INodeEdge
{
	public INode? Edge { get; }
}