
using System.Runtime.Serialization;
using System.Text.Json;

namespace F4lang.Dapr.Actors.Models;

[DataContract]
public class ActorRes : BaseActorMsg
{ 
    public virtual ActorRes Init<T>(T data)
    {
        this.Payload = JsonSerializer.Serialize(data);
        return this;
    }
}