namespace F4lang.Core;

public sealed class FileReader : IFileReader
{
    public async Task<string> ReadAllTextAsync(string filePath)
    {
        if(!File.Exists(filePath)) throw new FileNotFoundException($"File not found: {filePath}");

        var text = await File.ReadAllTextAsync(filePath);

        return text;
    }

    public string ReadAllText(string filePath)
    {
        if(!File.Exists(filePath)) throw new FileNotFoundException($"File not found: {filePath}");

        var text = File.ReadAllText(filePath);

        return text;
    }
}