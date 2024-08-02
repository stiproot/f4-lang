
using System.Text.Json.Serialization;

namespace F4lang.Core.Models;

public record AgntMetadataModel
{
    [JsonPropertyName("agntId")]
    public string AgntId { get; init; } = string.Empty;

    [JsonPropertyName("agntBaseType")]
    public string AgntBaseType { get; init; } = AgntBaseTypes.OPEN_AI;

    [JsonPropertyName("sysPrompts")]
    public IEnumerable<string> SysPrompts { get; init; } = [];

    [JsonPropertyName("fns")]
    public IEnumerable<AgntFn> Fns { get; init; } = [];

    [JsonPropertyName("agnts")]
    public IEnumerable<ReqAgnt> Agnts { get; init; } = [];

    [JsonPropertyName("collections")]
    public IEnumerable<AgntCollection> Collections { get; init; } = [];

    [JsonPropertyName("subs")]
    public IEnumerable<ReqAgnt> Subs { get; init; } = [];

    [JsonPropertyName("maxTokens")]
    public int MaxTokens { get; init; } = 500;

    [JsonPropertyName("temperature")]
    public float Temperature { get; init; } = 0.8f;

    [JsonPropertyName("contexts")]
    public IEnumerable<AgntCollection> Contexts { get; init; } = [];

    public string SysPrompt => string.Join("\n", this.SysPrompts);
}