using System.Text.Json;
using Azure.AI.OpenAI;
using Microsoft.DotNet.Interactive.AIUtilities;

public static class FnDefBuilder
{
    public static FunctionDefinition Build(GptFunction function)
    {
        var fnDef = new FunctionDefinition(function.Name);
        var json = JsonDocument.Parse(function.JsonSignature.ToString()).RootElement;
        fnDef.Parameters = BinaryData.FromString(json.GetProperty("parameters").ToString());
        return fnDef;
    }
}