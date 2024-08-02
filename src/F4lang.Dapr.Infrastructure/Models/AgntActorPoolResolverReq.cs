
using System.Runtime.Serialization;

namespace F4lang.Dapr.Infrastructure.Models;

// [DataContract]

[DataContract]
public record AgntActorPoolResolverReq
{
  [DataMember(Name = "agntIds")]
  public IEnumerable<string> AgntIds { get; init; } = [];

  [DataMember(Name = "leaderAgntId")]
  public string LeaderAgntId { get; init; } = string.Empty;

  [DataMember(Name = "rawTxtQry")]
  public string RawTxtQry { get; init; } = string.Empty;
}