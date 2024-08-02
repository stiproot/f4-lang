
namespace F4lang.Fns;

public class TranslateYmlToJson : IFnBuilder
{
    public string Key => FnNames.TRANSLATE_YML_JSON;

    public Delegate Build()
    {
        return (string yml) => 
        {
            Console.WriteLine($"Invoking function: {Key}");
            return YmlTranslator.YamlToJson(yml);
        };
    }
}