
namespace Generic.Cb.Abstractions;

public interface ICoreCbClient
{
    Task<IEnumerable<TRes>> QueryScopeAsync<TRes>(
        string scopeName, 
        string query
    );

    Task UpsertDocumentAsync(
        string scopeName,
        string collectionName,
        string documentId,
        object document
    );
}
