namespace F4lang.Builder.Abstractions;

/// <inheritdoc cref="INodeResolver"/>
public interface INodeResolver
{
	/// <inheritdoc />
	Task<IMsg[]> ResolveAsync(
		INode node,
		CancellationToken cancellationToken
	);
}
