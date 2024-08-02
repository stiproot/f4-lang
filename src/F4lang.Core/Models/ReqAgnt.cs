
using System.Text.Json.Serialization;

namespace F4lang.Core.Models;

public record ReqAgnt
{
    [JsonPropertyName("agntId")]
    public string AgntId { get; init; } = string.Empty;

    [JsonPropertyName("agntDesc")]
    public string AgntDesc { get; init; } = string.Empty;
}