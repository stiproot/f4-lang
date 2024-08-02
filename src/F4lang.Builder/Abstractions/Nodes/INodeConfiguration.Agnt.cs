namespace F4lang.Builder.Abstractions;

public partial interface INodeConfiguration
{
    IList<Type> FnTypes { get; init; }
	IList<(Type, Action<IMsg>)> ArgEnrichers { get; init; }
}