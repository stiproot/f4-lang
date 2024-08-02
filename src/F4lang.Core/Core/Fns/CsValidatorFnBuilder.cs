using Generic.FileParsers.Abstractions;

namespace F4lang.Core;

public class CsValidatorFnBuilder(
    IFileReader fileReader,
    ICsValidator csValidator
) : IFnBuilder
{
    private readonly IFileReader _fileReader = fileReader;
    private readonly ICsValidator _csValidator = csValidator;
    public string Key => FnNames.VALIDATE_CS_CMD;

    public Delegate Build()
    {
        return (string filePath) =>
        {
            Console.WriteLine($"Invoking function: {this.Key}");
            string code = this._fileReader.ReadAllText(filePath);
            var res = this._csValidator.Validate(code);
        };
    }
}