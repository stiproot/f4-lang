
namespace F4lang.Core.Abstractions;

public interface IFileReader
{
    Task<string> ReadAllTextAsync(string filePath);
    string ReadAllText(string filePath);
}