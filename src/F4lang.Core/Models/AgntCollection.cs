
using System.Text.Json.Serialization;

namespace F4lang.Core.Models;

public class AgntCollection
{
    [JsonPropertyName("collName")]
    public string CollName { get; init; } = string.Empty;

    [JsonPropertyName("collDesc")]
    public string CollDesc { get; init; } = string.Empty;

    [JsonPropertyName("collQryHint")]
    public string CollQryHint { get; init; } = string.Empty;
}