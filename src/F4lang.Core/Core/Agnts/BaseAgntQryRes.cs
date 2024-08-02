using System.Runtime.Serialization;
using Azure.AI.OpenAI;

namespace F4lang.Core;

[DataContract]
[KnownType(typeof(AgntQryRes))]
public abstract record BaseAgntQryRes : IAgntQryRes
{
    [DataMember(Name = "rawTxtRes")]
    public string RawTxtRes { get; init; } = string.Empty;

    [DataMember(Name = "extRes")]
    public Azure.Response<ChatCompletions>? ExtRes { get; init; }

    [DataMember(Name = "status")]
    public AgntQryResStatus Status { get; set; } = AgntQryResStatus.PROCESSING;

    public IAgntQryRes Log()
    {
        Console.WriteLine(this.RawTxtRes);
        return this;
    }
}