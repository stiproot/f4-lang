
namespace F4lang.Builder.Abstractions;

internal interface IDecisionFnFactory
{
	Func<IArgs, IMsg?> Create(
		ControllerTypes? controllerType,
		bool resolveTo = true,
		string? value = null
	);
}