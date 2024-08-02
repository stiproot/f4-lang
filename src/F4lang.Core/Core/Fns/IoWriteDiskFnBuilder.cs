namespace F4lang.Core;

public class IoWriteDiskFnBuilder(IFileWriter fileWriter) : IFnBuilder
{
    private readonly IFileWriter _fileWriter = fileWriter;
    public string Key => FnNames.IO_WRITE_DISK;

    public Delegate Build()
    {
        return (string fileContent, string filePath) => 
        {
            Console.WriteLine($"Invoking function: {this.Key}");
            this._fileWriter.WriteAllText(fileContent, filePath);
        };
    }
}