using System.Text.Json;

namespace F4lang.Core;

public sealed class ConfigLoader : IConfigLoader
{
    public async Task<IEnumerable<IAgntConfiguration>> Load()
    {
        var config = await File.ReadAllTextAsync("config.json");
        var objs = JsonSerializer.Deserialize<IEnumerable<IAgntConfiguration>>(config)!;
        return objs;
    }
}