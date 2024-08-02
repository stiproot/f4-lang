
namespace F4lang.Builder.Extensions;

public static class MsgExtensions
{
	public static IMsg[] ToArray(this IMsg? @this) 
		=> @this is null ? [] : [@this];

	public static IArgs AsArgs(this List<IMsg> @this) 
		=> new Args(@this);

	public static bool Matches<TData>(this List<IMsg> @this,
		string paramName,
		TData data
	)
		=> @this.Any(m => m.ParamName == paramName && m.Data<TData>()!.Equals(data));

	public static TData Data<TData>(this IMsg @this) 
		=> (@this as Msg<TData>)!.GetData();
}