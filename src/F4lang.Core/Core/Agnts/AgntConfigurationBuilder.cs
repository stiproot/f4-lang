
namespace F4lang.Core.Agnts;

public class AgntConfigurationBuilder : IAgntConfigurationBuilder
{
    private IAgntMemory? _agntMemory;
    private AgntMetadataModel? _agntMetadata;

    public IAgntConfigurationBuilder AddMetadata(AgntMetadataModel agntMetadata)
    { 
        this._agntMetadata = agntMetadata;
        return this;
    }

    public IAgntConfigurationBuilder AddMemory(IAgntMemory agntMemory)
    {
        this._agntMemory = agntMemory;
        return this;
    }

    public IAgntConfigurationBuilder AddCache(IAgntMemory agntMemory)
    { 
        throw new NotImplementedException();
    }

    public IAgntConfiguration Build()
    { 
        return new AgntConfiguration
        {
            Metadata = this._agntMetadata!, 
            Memory = this._agntMemory!, 
        };
    }
}
