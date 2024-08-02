
namespace Generic.Caching.Abstractions;

public interface ICache
{
    Task<T?> GetOrCreateAsync<T>(
        string key,
        Func<ICacheEntry, Task<T>> factory
    );

    bool TryGetValueType<T>(
         string key,
         out T value
     ) where T : struct;

    bool TryGetReferenceType<T>(
        string key,
        out T? value
    ) where T : class;

    T Set<T>(
        string key,
        T value
    );
}
