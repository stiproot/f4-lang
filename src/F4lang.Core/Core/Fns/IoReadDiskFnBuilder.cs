namespace F4lang.Core;

public class IoReadDiskFnBuilder(IFileReader fileReader) : IFnBuilder
{
    private readonly IFileReader _fileReader = fileReader;
    public string Key => FnNames.IO_READ_DISK;

    public Delegate Build()
    {
        return (string filePath) =>
        {
            Console.WriteLine($"Invoking function: {this.Key}");
            return this._fileReader.ReadAllText(filePath);
        };
    }
}