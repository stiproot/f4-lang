namespace Slow.Core.Abstractions;

public interface IAgentConfigurationBuilder
{
    IAgentConfigurationBuilder AddMetadata(IAgentMetadata agentMetadata);
    IAgentConfigurationBuilder AddMemory(IAgentMemory agentMemory);
    IAgentConfigurationBuilder AddCache(IAgentMemory agentMemory);
    IAgentConfigurationBuilder AddFn(IAgentFn agentFn);
    IAgentConfiguration Build();
}
