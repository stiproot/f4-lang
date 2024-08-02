
namespace F4lang.Builder.Abstractions;

public interface IAgntBranch
{
	IStateManager AgntRoot<T>(Action<INodeConfigurationBuilder>? configure = null);

	IStateManager Pair<T, V>(
		Action<INodeConfigurationBuilder>? configureT = null,
		Action<INodeConfigurationBuilder>? configureV = null,
		Action<IStateManager>? then = null,
		Action<IStateManager>? @else = null
	);

	IStateManager Decision<V>(
		Action<INodeConfigurationBuilder>? configureV = null,
		Action<IStateManager>? then = null,
		Action<IStateManager>? @else = null
	);

	IStateManager ContinuumPair<T, V>(
		Action<INodeConfigurationBuilder>? configureT = null,
		Action<INodeConfigurationBuilder>? configureV = null,
		Action<IStateManager>? then = null
	);


	IStateManager IsValid<T>(Action<INodeConfigurationBuilder>? configure = null);
}