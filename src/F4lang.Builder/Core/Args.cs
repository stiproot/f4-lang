
namespace F4lang.Builder.Abstractions;

public class Args(IList<IMsg> args) : IArgs
{
	private readonly IList<IMsg> _args = args;

	public IMsg? this[string? key]
		=> this._args?.FirstOrDefault(a => a?.ParamName == key);

	public object[] ToObjArray()
		=> this._args.Any() ? this._args.Select(a => a!.ObjectData).ToArray() : [];

	public object[] ToObjArray(IEnumerable<ParameterInfo> @params)
	{
		if (this._args?.Any() is false) return [];

		var objs = this.ToObjArray();

		IList<object> returnObjs = [];

		foreach (var p in @params)
		{
			var argV = this[p.Name];

			// In some cases the msgs in _args may not have a ParamName set.
			if (argV is not null) returnObjs.Add(argV.ObjectData);
			else
			{
				// Try find the first arg object that matches the parameter type.
				var argVObj = objs.Where(o => IsType(p.ParameterType, o)).FirstOrDefault();

				if (argVObj is not null) returnObjs.Add(argVObj);
				else throw new InvalidOperationException($"Can't find a matching parameter for {p.Name}");
			}
		}

		return [.. returnObjs];
	}

	private static bool IsType(
		Type paramType,
		object arg
	)
	{
		var argType = arg.GetType();
		
		return paramType == argType || paramType == argType.BaseType || paramType == argType.GetInterface(paramType.Name);
	}

	public string?[] Params()
		=> this._args!.Select(a => a?.ParamName).ToArray();

	public IMsg? First()
		=> this._args!.FirstOrDefault();

	public int Count()
		=> this._args?.Count ?? 0;
}