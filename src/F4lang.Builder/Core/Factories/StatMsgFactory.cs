namespace F4lang.Builder.Factories;

public static class StatMsgFactory
{
	/// <inheritdoc />
	public static IMsg Create<T>(
		T data,
		string? paramName = null
	) 
		=> paramName == null ? new Msg<T>(data) : new Msg<T>(data, paramName);
}
