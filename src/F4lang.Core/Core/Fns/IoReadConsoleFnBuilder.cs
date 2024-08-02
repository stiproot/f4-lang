namespace F4lang.Core;

public class IoReadConsoleFnBuilder() : IFnBuilder
{
    public string Key => FnNames.IO_READ_CONSOLE;

    public Delegate Build()
    {
        return (string infoQry) => 
        {
            Console.WriteLine($"Invoking function: {this.Key}");
            var consoleInput = Console.ReadLine();
            return consoleInput;
        };
    }
}