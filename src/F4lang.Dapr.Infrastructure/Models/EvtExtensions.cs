using System.Text.Json;

namespace F4lang.Dapr.Infrastructure.Models;

public static class EvtExtensions
{
  public static EvtMetadata DeserializeMetadata(this Evt @this)
  {
    return JsonSerializer.Deserialize<EvtMetadata>(@this.EvtMetadata, new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    })!;
  }

  public static EvtData DeserializeData(this Evt @this)
  {
    return JsonSerializer.Deserialize<EvtData>(@this.EvtData, new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    })!;
  }
}
