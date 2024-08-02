namespace F4lang.Builder.Abstractions;

public interface IRootBranch
{
	IStateManager Root<T>(Action<INodeConfigurationBuilder>? configure = null);
}