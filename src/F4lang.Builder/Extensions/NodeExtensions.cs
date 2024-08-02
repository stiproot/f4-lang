
namespace F4lang.Builder.Extensions;

internal static class NodeExtensions
{
	public static INode AddArg(this INode @this,
		IList<IMsg?> args
	)
	{
		TryEnrichMsgWithNextParamName(@this, args);

		@this.NodeConfiguration.Args.AddRange(args.NonNull());

		return @this;
	}
	
	// use this?
	private static void TryEnrichMsgWithNextParamName(
		INode node,
		IList<IMsg?> msgs
	)
	{
		if (!node.NodeConfiguration.RequiresResult) return;

		if (msgs.Count == 1 && msgs[0]?.ParamName is null)
		{
			string? paramName = TypeInspector.MatchTypeToMethodSignature(msgs[0]!.ObjectData.GetType(), node.Fn.ServiceType);
			if (paramName is not null) msgs[0]!.ParamName = paramName;
		}
	}
}

	