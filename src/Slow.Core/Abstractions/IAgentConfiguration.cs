namespace Slow.Core.Abstractions;

public interface IAgentConfiguration
{
    IAgentMetadata Metadata { get; init; }
    IAgentMemory Memory { get; init; }
    IAgentCache Cache { get; init; }
    IEnumerable<IAgentFn> Fns { get; init; }
}