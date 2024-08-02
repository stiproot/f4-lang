using Azure.AI.OpenAI;
using Microsoft.DotNet.Interactive.AIUtilities;

namespace F4lang.Core.Abstractions;

public interface ILazyFnHashInit
{
    ILazyFnHashInit Init(
        ref Dictionary<string, Delegate> fnDelHash,
        ref Dictionary<string, GptFunction> gptFnHash,
        ref Dictionary<string, FunctionDefinition> fnDefHash
    );
}