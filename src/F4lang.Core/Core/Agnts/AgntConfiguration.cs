
namespace F4lang.Core.Agnts;

public sealed class AgntConfiguration : IAgntConfiguration
{
    public AgntMetadataModel Metadata { get; init; } = new AgntMetadataModel();
    public IAgntMemory Memory { get; init; } = new EmptyAgntMemory();
}