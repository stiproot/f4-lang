
namespace F4lang.Builder.Core;

public class ContextusNodeEdge(string key) : IContextusNodeEdge
{
	public NodeEdgeTypes NodeEdgeType => NodeEdgeTypes.Contextus;
    public string Key { get; internal set; } = key;
}