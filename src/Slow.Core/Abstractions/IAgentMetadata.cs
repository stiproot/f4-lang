namespace Slow.Core.Abstractions;

public interface IAgentMetadata
{
    string SysPrompt { get; init; }
    IEnumerable<string> Options { get; init; }
}