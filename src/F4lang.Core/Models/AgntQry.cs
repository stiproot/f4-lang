
using Azure.AI.OpenAI;

namespace F4lang.Core.Models;

public class AgntQry : IAgntQry
{
    public string RawTxtQry { get; init; } = string.Empty;
    public AgntChat AgntChat { get; init; } = new();
    public IEnumerable<FunctionDefinition> FnDefs { get; init; } = [];
}