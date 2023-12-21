using Microsoft.Extensions.Caching.Memory;

namespace Slow.Core.Agents;

public sealed class AgentCache(IMemoryCache memoryCache) : IAgentCache
{
    private readonly IMemoryCache _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
}