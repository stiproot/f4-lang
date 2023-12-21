namespace Slow.Core.Abstractions;

public interface IFileReader
{
    Task<string> ReadAllTextAsync(string filePath);
}