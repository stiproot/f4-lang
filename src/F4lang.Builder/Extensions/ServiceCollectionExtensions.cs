
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace F4lang.Builder.Extensions;

/// <summary>
///   <see cref="IServiceCollection"/> extension methods.
/// </summary>
public static class ServiceCollectionExtensions
{
	/// <summary>
	///   Add all F4lang.Builder services to <see cref="IServiceCollection"/>.
	/// </summary>
	/// <returns><see cref="IServiceCollection"/></returns>
	public static IServiceCollection AddSlowBuilderServices(this IServiceCollection @this)
	{
		@this.TryAddSingleton<IFnFactory, FnFactory>();
		@this.TryAddSingleton<IMetaNodeMapper, MetaNodeMapper>();
		@this.TryAddSingleton<INodeBuilderFactory, NodeBuilderFactory>();
		@this.TryAddSingleton<IStateManager, StateManager>();
		@this.TryAddSingleton<IMsgFactory, MsgFactory>();
		@this.TryAddSingleton<IWorkflowContextFactory, WorkflowContextFactory>();
		@this.TryAddSingleton<INodeResolver, NodeResolver>();
		@this.TryAddSingleton<INodeEdgeResolver, NodeEdgeResolver>();
		@this.TryAddSingleton<IArgResolver, ParallelArgResolver>();
		@this.TryAddSingleton<IServiceProviderAdaptor, ServiceProviderAdaptor>();
		@this.TryAddSingleton<IActorServiceProvider, ActorServiceProvider>();
		@this.TryAddSingleton<IAgntDecisionNodeResolver, AgntDecisionNodeResolver>();

		return @this;
	}
}
