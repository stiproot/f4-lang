namespace Slow.Core;

public sealed class FileReader : IFileReader
{
    public async Task<string> ReadAllTextAsync(string filePath)
    {
        if(!File.Exists(filePath)) throw new FileNotFoundException($"File not found: {filePath}");

        var text = await File.ReadAllTextAsync(filePath);

        return text;
    }
}