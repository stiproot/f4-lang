using Azure.AI.OpenAI;

namespace F4lang.Core.Abstractions;

public interface IAgntQryRes
{
    string RawTxtRes { get; init; }
    IAgntQryRes Log();
    Azure.Response<ChatCompletions>? ExtRes { get; init; }
    AgntQryResStatus Status { get; set; }
}