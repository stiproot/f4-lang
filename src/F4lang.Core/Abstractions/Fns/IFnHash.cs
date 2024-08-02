using Azure.AI.OpenAI;
using Microsoft.DotNet.Interactive.AIUtilities;

namespace F4lang.Core.Abstractions;

public interface IFnHash
{
    Delegate GetFnDel(string key);
    GptFunction GetGptFn(string key);
    FunctionDefinition GetFnDef(string key);
}