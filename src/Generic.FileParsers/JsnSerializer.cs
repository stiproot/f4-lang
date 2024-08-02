
using System.Text.Json;
using System.Text.Json.Serialization;
using Generic.FileParsers.Abstractions;

namespace Generic.FileParsers;

public class JsnSerializer : IJsnSerializer
{
    private static readonly JsonSerializerOptions s_deserializeOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
    };

    public T Deserialize<T>(string jsn)
    {
        var obj = JsonSerializer.Deserialize<T>(jsn, s_deserializeOptions);
        return obj;
    }
}
