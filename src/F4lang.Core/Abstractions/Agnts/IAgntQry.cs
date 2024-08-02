
using Azure.AI.OpenAI;

namespace F4lang.Core.Abstractions;

public interface IAgntQry
{
    string RawTxtQry { get; init; }
    AgntChat AgntChat { get; init; }
    IEnumerable<FunctionDefinition> FnDefs { get; init; }
}