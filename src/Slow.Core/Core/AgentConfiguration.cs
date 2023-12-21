namespace Slow.Core;

public sealed class AgentConfiguration : IAgentConfiguration
{
    public IAgentMetadata Metadata { get; init; } = new AgentMetadata();
    public IAgentMemory Memory { get; init; } = new EmptyAgentMemory();
    public IAgentCache Cache { get; init; } = new EmptyAgentCache();
    public IEnumerable<IAgentFn> Fns { get; init; } = new List<IAgentFn>();
}