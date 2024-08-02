using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace F4lang.Dapr.Infrastructure.Models;

// [DataContract]
public record GetAgntReq
{
  [JsonPropertyName("agntId")]
  // [DataMember(Name = "agntId")]
  public string AgntId { get; init; } = string.Empty;
}