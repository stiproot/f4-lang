
using System.Runtime.Serialization;
using System.Text.Json;

namespace F4lang.Dapr.Actors.Abstractions;

[DataContract]
[KnownType(typeof(ActorCmd))]
[KnownType(typeof(ActorRes))]
public abstract class BaseActorMsg
{
    [DataMember(Name = "payload")]
    protected virtual string Payload { get; set; } = string.Empty;
    public virtual T? Deserialize<T>() => JsonSerializer.Deserialize<T>(this.Payload);
}