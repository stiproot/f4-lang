
using System.Text.Json.Serialization;

namespace F4lang.Dapr.Infrastructure.Models;

public class PubSubMsg2
{
    [JsonPropertyName("data")]
    public string Data { get; init; } = string.Empty;

    [JsonPropertyName("datacontenttype")]
    public string DataContentType { get; init; } = string.Empty;

    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("pubsubname")]
    public string PubSubName { get; init; } = string.Empty;

    [JsonPropertyName("source")]
    public string Source { get; init; } = string.Empty;

    [JsonPropertyName("specversion")]
    public string SpecVersion { get; init; } = string.Empty;

    [JsonPropertyName("time")]
    public string Time { get; init; } = string.Empty;

    [JsonPropertyName("topic")]
    public string Topic { get; init; } = string.Empty;

    [JsonPropertyName("traceid")]
    public string TraceId { get; init; } = string.Empty;

    [JsonPropertyName("traceparent")]
    public string Traceparent { get; init; } = string.Empty;

    [JsonPropertyName("tracestate")]
    public string Tracestate { get; init; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;
}