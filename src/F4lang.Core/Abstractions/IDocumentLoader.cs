namespace F4lang.Core.Abstractions;

public interface IDocumentLoader
{
    Task LoadAsync(IEnumerable<DocumentModel> documents);
}