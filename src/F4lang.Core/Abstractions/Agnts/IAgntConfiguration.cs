namespace F4lang.Core.Abstractions;

public interface IAgntConfiguration
{
    AgntMetadataModel Metadata { get; init; }
    IAgntMemory Memory { get; init; }
}