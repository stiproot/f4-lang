
using Azure.AI.OpenAI;

namespace F4lang.Core;

public sealed class DefaultOpenAIAgnt(OpenAIClient openAIClient) : BaseOpenAIAgnt(openAIClient), IAgnt
{
    private uint counter = 0;

    public IAgnt Configure() => this;

    public async Task<IAgntQryRes> ProcessQryAsync(IAgntQry qry)
    {
        counter++;
        if (counter > 3) return EndProcess(AgntQryResStatus.ERROR);

        Console.WriteLine("Calling Completations endpoint with System Prompt:");
        Console.WriteLine($"FnDefs: {qry.FnDefs.Count()}");

        var chatCompletionOptions = new ChatCompletionsOptions
        {
            Messages =
            {
                new ChatRequestSystemMessage(qry.AgntChat.Build()),
                new ChatRequestUserMessage(qry.RawTxtQry)
            },
            DeploymentName = OpenAIModelVers.GPT_4_TURBO,
        };

        foreach(var fn in qry.FnDefs)
        {
            chatCompletionOptions.Functions.Add(fn);
        }


        Azure.Response<ChatCompletions> resp = await this._Client.GetChatCompletionsAsync(chatCompletionOptions);

        return new AgntQryRes { ExtRes = resp, Status = AgntQryResStatus.PROCESSING };
    }
}