
namespace Generic.Caching;

public class Cache(IMemoryCache memoryCache) : ICache
{
    private readonly IMemoryCache _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));

    public Task<T?> GetOrCreateAsync<T>(
        string key,
        Func<ICacheEntry, Task<T>> factory
    )
        => this._memoryCache.GetOrCreateAsync<T>(key, factory);

    public bool TryGetValueType<T>(
        string key,
        out T value
    ) where T : struct
    {
        if (this._memoryCache.TryGetValue<T>(key, out T v))
        {
            value = v;
            return true;
        }
        value = default(T);
        return false;
    }

    public bool TryGetReferenceType<T>(
        string key,
        out T? value
    ) where T : class
    {
        if (this._memoryCache.TryGetValue<T>(key, out T? v))
        {
            value = v;
            return true;
        }
        value = null;
        return false;
    }

    public T Set<T>(
        string key,
        T value
    )
    {
        return this._memoryCache.Set<T>(key, value);
    }
}
