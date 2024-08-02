using System.Text.Json.Serialization;

namespace F4lang.Dapr.Infrastructure.Models;

public class Evt
{
  [JsonPropertyName("evtType")]
  public EvtType EvtType { get; set; }

  [JsonPropertyName("evtMetadata")]
  public string EvtMetadata { get; init; } = string.Empty;

  [JsonPropertyName("evtData")]
  public string EvtData { get; init; } = string.Empty;
}