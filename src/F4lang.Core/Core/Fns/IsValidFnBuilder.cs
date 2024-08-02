namespace F4lang.Core;

public class IsValidFnBuilder : IFnBuilder
{
    public string Key => FnNames.IS_VALID;

    public Delegate Build()
    {
        return (bool isValid) => 
        {
            Console.WriteLine($"Invoking function: {this.Key}");
            return isValid;
        };
    }
}