using Microsoft.SemanticKernel.Memory;

#pragma warning disable SKEXP0001, SKEXP0022, SKEXP0052, SKEXP0003

namespace F4lang.Core;

public class DocumentLoader(
    IFactory<ISemanticTextMemory> memoryFactory,
    IFileReader fileReader
) : IDocumentLoader
{
    private readonly IFactory<ISemanticTextMemory> _memoryFactory = memoryFactory ?? throw new ArgumentNullException(nameof(memoryFactory));
    private readonly IFileReader _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));

    public async Task LoadAsync(IEnumerable<DocumentModel> documents)
    {
        var memory = this._memoryFactory.Create();
        await Task.WhenAll(documents.Select(async d => 
        {
            string text = await this._fileReader.ReadAllTextAsync(d.FilePath);
            Console.WriteLine($"Persisting contents to vector store:\n{text}");
            await memory.SaveInformationAsync(collection:d.CollectionName, text:text, id:d.Id, description:d.Description);
        }));
    }
}