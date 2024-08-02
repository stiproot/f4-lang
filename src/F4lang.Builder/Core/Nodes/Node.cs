
namespace F4lang.Builder.Abstractions;

/// <inheritdoc cref="INode"/>
public class Node : INode
{
	public INodeConfiguration NodeConfiguration { get; init; } = default!;
	public INodeResolver Resolver { get; init; } = default!;
	public INodeEdge? NodeEdge { get; init; }
	public IController? Controller { get; init; }
	public IFn Fn { get; init; } = default!;
	public Func<Exception, Task>? AsyncExceptionHandler { get; init; }
	public Action<Exception>? ExceptionHandler { get; init; }

	/// <inheritdoc />
	public virtual async Task<IMsg[]> Resolve(CancellationToken cancellationToken)
		=> await this.Resolver.ResolveAsync(this, cancellationToken);

	/// <inheritdoc />
	public virtual void Validate()
	{
		if (this.Fn is null) throw new InvalidOperationException("Fn has not been set.");
	}
}
