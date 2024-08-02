
namespace F4lang.Builder.Core;

public class InjectableDecisionFlowControlFnBuilder(
    INode @true,
    INode? @false = null
) : IFnBuilder
{
    public string Key => "IS_VALID";
    private readonly INode True = @true;
    private INode? False = @false;

    public void SetFalse(INode node) => this.False = node;

    public Delegate Build()
    {
        return (bool valid) => 
        {
            Console.WriteLine($"Invoking function: {this.Key}");

            return valid ? True : False ?? throw new InvalidOperationException("False decision node is null.");
        };
    }
}