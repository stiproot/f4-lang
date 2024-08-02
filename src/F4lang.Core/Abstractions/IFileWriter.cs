
namespace F4lang.Core.Abstractions;

public interface IFileWriter
{
    Task WriteAllTextAsync(
        string fileContent, 
        string filePath
    );

    void WriteAllText(
        string fileContent, 
        string filePath
    );
}