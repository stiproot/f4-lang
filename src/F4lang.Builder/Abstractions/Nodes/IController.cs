namespace F4lang.Builder.Abstractions;

public interface IController
{
	bool Control(IMsg? msg);
}