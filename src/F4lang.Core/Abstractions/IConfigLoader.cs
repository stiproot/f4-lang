namespace F4lang.Core.Abstractions;

public interface IConfigLoader
{
    Task<IEnumerable<IAgntConfiguration>> Load();
}