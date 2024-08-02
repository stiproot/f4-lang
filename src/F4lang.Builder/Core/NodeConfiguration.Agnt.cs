namespace F4lang.Builder.Core;

public partial class NodeConfiguration : INodeConfiguration
{
    public IList<Type> FnTypes { get; init; } = [];
	public IList<(Type, Action<IMsg>)> ArgEnrichers { get; init; } = [];
}