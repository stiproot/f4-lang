using System.Text.Json;

namespace Slow.Core;

public sealed class ConfigLoader : IConfigLoader
{
    public async Task<IEnumerable<IAgentConfiguration>> Load()
    {
        var config = await File.ReadAllTextAsync("config.json");
        var objs = JsonSerializer.Deserialize<IEnumerable<IAgentConfiguration>>(config)!;
        return objs;
    }
}