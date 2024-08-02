
using Azure.AI.OpenAI;

namespace F4lang.Core.Abstractions;

public abstract class BaseOpenAIAgnt(OpenAIClient openAIClient) : BaseAgnt
{
    protected readonly OpenAIClient _Client = openAIClient ?? throw new ArgumentNullException(nameof(openAIClient));
}