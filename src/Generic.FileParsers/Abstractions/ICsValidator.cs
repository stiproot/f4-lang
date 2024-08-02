
namespace Generic.FileParsers.Abstractions;

public interface ICsValidator
{
    ICsValidatorRes Validate(string code);
}