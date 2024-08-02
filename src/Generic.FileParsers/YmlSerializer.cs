
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Generic.FileParsers.Abstractions;

namespace Generic.FileParsers;

public class YmlSerializer : IYmlSerializer
{
    public T Deserialize<T>(string yaml)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        var obj = deserializer.Deserialize<T>(new StringReader(yaml));

        return obj;
    }
}
