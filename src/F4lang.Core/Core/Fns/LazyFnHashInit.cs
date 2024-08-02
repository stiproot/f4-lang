using Azure.AI.OpenAI;
using Microsoft.DotNet.Interactive.AIUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace F4lang.Core;

public class LazyFnHashInit(IServiceProvider serviceProvider) : ILazyFnHashInit
{
    private readonly IServiceProvider _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

    public ILazyFnHashInit Init(
        ref Dictionary<string, Delegate> fnDelHash,
        ref Dictionary<string, GptFunction> gptFnHash,
        ref Dictionary<string, FunctionDefinition> fnDefHash
    )
    {
        var hasheBuilders = this._serviceProvider.GetServices<IFnBuilder>();

        foreach(var builder in hasheBuilders)
        {
            Delegate fn = builder.Build();
            GptFunction gptFn = GptFunction.Create(builder.Key, fn, enumsAsString:true);
            FunctionDefinition fnDef = FnDefBuilder.Build(gptFn);

            fnDelHash.TryAdd(builder.Key, fn);
            gptFnHash.TryAdd(builder.Key, gptFn);
            fnDefHash.TryAdd(builder.Key, fnDef);
        }

        return this;
    }
}