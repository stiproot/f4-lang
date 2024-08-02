namespace F4lang.Builder.Factories;

/// <inheritdoc cref="IWorkflowContextFactory"/>
public class WorkflowContextFactory : IWorkflowContextFactory
{
	/// <inheritdoc />
	public IWorkflowContext Create() => new WorkflowContext();
}
