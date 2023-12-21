namespace Slow.Core.Abstractions;

public interface IDocumentLoader
{
    Task LoadAsync(IEnumerable<DocumentModel> documents);
}