namespace Slow.Core;

public sealed class AgentConfigurationBuilder : IAgentConfigurationBuilder
{
    private IAgentMemory? _agentMemory;
    private IAgentMetadata? _agentMetadata;
    private readonly List<IAgentFn> _agentFns = new();

    public IAgentConfigurationBuilder AddMetadata(IAgentMetadata agentMetadata)
    { 
        this._agentMetadata = agentMetadata;
        return this;
    }

    public IAgentConfigurationBuilder AddMemory(IAgentMemory agentMemory)
    {
        this._agentMemory = agentMemory;
        return this;
    }

    public IAgentConfigurationBuilder AddCache(IAgentMemory agentMemory)
    { 
        throw new NotImplementedException();
    }

    public IAgentConfigurationBuilder AddFn(IAgentFn agentFn)
    { 
        throw new NotImplementedException();
    }

    public IAgentConfiguration Build()
    { 
        return new AgentConfiguration
        {
            Metadata = this._agentMetadata!, 
            Memory = this._agentMemory!, 
            Fns = this._agentFns
        };
    }
}
