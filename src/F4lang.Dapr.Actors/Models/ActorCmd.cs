
using System.Runtime.Serialization;
using System.Text.Json;

namespace F4lang.Dapr.Actors.Models;

[DataContract]
public class ActorCmd : BaseActorMsg 
{ 
    public virtual ActorCmd Init<T>(T data)
    {
        this.Payload = JsonSerializer.Serialize(data);
        return this;
    }
}