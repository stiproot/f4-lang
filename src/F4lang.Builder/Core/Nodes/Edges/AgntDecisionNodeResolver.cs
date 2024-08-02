
namespace F4lang.Builder.Core;

/// <inheritdoc cref="INode"/>
/// <summary>
///   Initializes a new instance of <see cref="Node"/>. 
/// </summary>
public class AgntDecisionNodeResolver(INodeResolver nodeResolver) : IAgntDecisionNodeResolver
{
	protected readonly INodeResolver _NodeResolver = nodeResolver ?? throw new ArgumentNullException(nameof(nodeResolver));

	/// <inheritdoc />
	public virtual async Task<IMsg[]> ResolveAsync(IAgntManagerQryRes qryRes)
	{
		var node = qryRes.CallbackRes as INode;
		var cancellationToken = new CancellationToken();

		return await this._NodeResolver.ResolveAsync(node!, cancellationToken);
	}
}
