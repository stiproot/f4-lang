namespace Slow.Core;

public class AgentMetadata : IAgentMetadata
{
    public string SysPrompt { get; init; } = string.Empty;
    public IEnumerable<string> Options { get; init; } = new List<string>();
}