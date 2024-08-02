namespace F4lang.Core.Abstractions;

public interface IFnBuilder
{
    string Key { get; }
    Delegate Build();
}