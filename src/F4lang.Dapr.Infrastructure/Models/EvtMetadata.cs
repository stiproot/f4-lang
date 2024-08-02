using System.Text.Json.Serialization;

namespace F4lang.Dapr.Infrastructure.Models;

public class EvtMetadata
{
  [JsonPropertyName("id")]
  public string Id { get; init; } = string.Empty;
}