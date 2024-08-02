
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace F4lang.Fns;

public static class YmlTranslator
{
    public static string YamlToJson(string yml)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        object obj = deserializer.Deserialize(yml)!;
        string jsn = JsonConvert.SerializeObject(obj);
        JArray jArr = JArray.Parse(jsn);
        JObject jObj = jArr.First!.Value<JObject>()!;

        Enrich(jObj);

        return jObj.ToString(Formatting.Indented);
    }

    public static void Enrich(JObject jObj)
    {
        JToken? children = jObj["children"];

        if (children?.Type == JTokenType.Array)
        {
            foreach (var child in children)
            {
                AddProperty((JObject)child, "area_path", new JValue("Software\\Integrated Solutions, Sports and AI\\Artificial Intelligence\\Project\\Cyberdyne Project Team"));
                Enrich((JObject)child);
            }
        }
    }

    public static JObject AddProperty(
        JObject jsonObject,
        string propertyName,
        JValue propertyValue
    )
    {
        if (jsonObject.ContainsKey(propertyName))
        {
            throw new ArgumentException($"Property '{propertyName}' already exists in the object.");
        }

        jsonObject.Add(propertyName, propertyValue);

        return jsonObject;
    }
}

