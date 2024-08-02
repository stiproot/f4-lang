
namespace F4lang.Builder.Abstractions;

/// <inheritdoc cref="INodeResolver"/>
public interface IAgntDecisionNodeResolver
{
	/// <inheritdoc />
	Task<IMsg[]> ResolveAsync(IAgntManagerQryRes qryRes);
}
