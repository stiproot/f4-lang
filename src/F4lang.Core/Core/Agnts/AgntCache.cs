
using Generic.Caching.Abstractions;

namespace F4lang.Core.Agnts;

public sealed class AgntCache(ICache cache) : IAgntCache
{
    private readonly ICache _cache = cache ?? throw new ArgumentNullException(nameof(cache));

    public AgntChat? GetAgntChat(string agntId)
    { 
        if(this._cache.TryGetReferenceType<AgntChat>(agntId, out var agntChat))
        {
            return agntChat;
        }

        throw new KeyNotFoundException(agntId);
    }

    public void SetAgntChat(string agntId, AgntChat agntChat) => this._cache.Set(agntId, agntChat);
}