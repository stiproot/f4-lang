namespace F4lang.Core.Abstractions;

public interface IAgntConfigurationBuilder
{
    IAgntConfigurationBuilder AddMetadata(AgntMetadataModel agntMetadata);
    IAgntConfigurationBuilder AddMemory(IAgntMemory agntMemory);
    IAgntConfigurationBuilder AddCache(IAgntMemory agntMemory);
    IAgntConfiguration Build();
}
