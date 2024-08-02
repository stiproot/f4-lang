namespace F4lang.Builder.Abstractions;

public interface INodeEdgeResolver
{
	Task<IMsg[]> Resolve(
		INodeEdge nodeEdge, 
		IMsg[] msgs,
		IWorkflowContext? workflowContext,
		CancellationToken cancellationToken
	);
}