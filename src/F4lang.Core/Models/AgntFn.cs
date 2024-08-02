
using System.Text.Json.Serialization;

namespace F4lang.Core.Models;

public class AgntFn
{
    [JsonPropertyName("fnName")]
    public string FnName { get; init; } = string.Empty;

    [JsonPropertyName("fnDesc")]
    public string FnDesc { get; init; } = string.Empty;
}