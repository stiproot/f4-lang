namespace F4lang.Builder.Core;

public class TrueController : IController
{
	public bool Control(IMsg? msg)
	{
		if (msg is null) return false;

		return msg.Data<bool>();
	}
}