namespace F4lang.Core;

public sealed class FileWriter : IFileWriter
{
    public async Task WriteAllTextAsync(
        string fileContent, 
        string filePath
    )
    {
        await File.WriteAllTextAsync(filePath, fileContent);
    }

    public void WriteAllText(
        string fileContent, 
        string filePath
    )
    {
        Console.WriteLine($"FileWriter.WriteAllText(): filePath: {filePath}, fileContent: {fileContent}");
        File.WriteAllText(filePath, fileContent);
    }
}