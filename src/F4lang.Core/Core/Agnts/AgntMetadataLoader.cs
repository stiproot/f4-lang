using Generic.FileParsers.Abstractions;

namespace F4lang.Core;

public class AgntMetadataLoader(
    IFileReader fileReader,
    IYmlSerializer ymlSerializer,
    IJsnSerializer jsnSerializer
) : IAgntMetadataLoader
{
    private readonly IFileReader _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
    private readonly IYmlSerializer _ymlSerializer = ymlSerializer ?? throw new ArgumentNullException(nameof(ymlSerializer));
    private readonly IJsnSerializer _jsnSerializer = jsnSerializer ?? throw new ArgumentNullException(nameof(jsnSerializer));

    public async Task<AgntMetadataModel> LoadYmlAsync(string filePath)
    {
        var txt = await this._fileReader.ReadAllTextAsync(filePath);
        var metadata = _ymlSerializer.Deserialize<AgntMetadataModel>(txt);
        return metadata;
    }

    public async Task<AgntMetadataModel> LoadJsnAsync(string filePath)
    {
        var txt = await this._fileReader.ReadAllTextAsync(filePath);
        Console.WriteLine($"LoadJsnAsync: {txt}");
        var metadata = this._jsnSerializer.Deserialize<AgntMetadataModel>(txt);
        return metadata;
    }
}