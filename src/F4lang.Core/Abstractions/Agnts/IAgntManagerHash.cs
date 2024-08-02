using System.Collections.Concurrent;

namespace F4lang.Core.Abstractions;

public interface IAgntManagerHash
{
    ConcurrentDictionary<string, IAgntManager> Hash { get; }
    // Task<IAgntManagerHash> InitAsync(IOptions<AgntOptions> options);
    // Task<IAgntManagerHash> InitAsync(AgntPoolMetadataModel agntPoolMetadata);
    IAgntManagerHash Init(IEnumerable<AgntMetadataModel> agntMetadataModels);
    IAgntManager Get(string agntId);
}
