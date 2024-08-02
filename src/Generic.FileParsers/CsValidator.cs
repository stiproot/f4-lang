using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Generic.FileParsers.Abstractions;

namespace Generic.FileParsers;

public class CsValidator : ICsValidator
{
    public ICsValidatorRes Validate(string code)
    {
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);

        // Create a compilation with a custom in-memory assembly
        var compilation = CSharpCompilation.Create(
            "InMemoryAssembly",
            new[] { syntaxTree },
            new MetadataReference[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) },
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        // Emit IL to memory
        Stream stream = new MemoryStream();
        EmitResult result = compilation.Emit(stream);

        if (result.Success)
        {
            Console.WriteLine("Syntax is valid!");
        }
        else
        {
            Console.WriteLine("Compilation errors:");
            foreach (Diagnostic diagnostic in result.Diagnostics)
            {
                Console.WriteLine($"{diagnostic.Id}: {diagnostic.GetMessage()}");
            }
        }

        // invocation...

        // if (result.Success)
        // {
        //     // Load the emitted assembly
        //     Assembly assembly = result.Assembly;

        //     // Find a type and method to execute
        //     Type type = assembly.GetType("SomeNamespace.SomeType");
        //     MethodInfo method = type.GetMethod("SomeMethod");

        //     // Invoke the method (assuming it takes no arguments and returns void)
        //     method.Invoke(null, null);
        // }

        return new CsValidatorRes();
    }
}
