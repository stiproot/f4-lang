using System.Text.Json.Serialization;

namespace F4lang.Dapr.Infrastructure.Models;

public class EvtData
{
  [JsonPropertyName("agntId")]
  public string AgntId { get; init; } = string.Empty;

  [JsonPropertyName("agntQry")]
  public string AgntManagerQry { get; init; } = string.Empty;
}