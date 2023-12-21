namespace Slow.Core.Abstractions;

public interface IConfigLoader
{
    Task<IEnumerable<IAgentConfiguration>> Load();
}