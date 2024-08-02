using Azure.AI.OpenAI;
using Microsoft.DotNet.Interactive.AIUtilities;

namespace F4lang.Core;

public class FnHash : IFnHash
{
    private readonly ILazyFnHashInit _lazyFnHashInit;
    private readonly Dictionary<string, Delegate> _fnDelHash = [];
    private readonly Dictionary<string, GptFunction> _gptFnHash = [];
    private readonly Dictionary<string, FunctionDefinition> _fnDefHash = [];

    public FnHash(ILazyFnHashInit lazyFnHashInit)
    {
        this._lazyFnHashInit = lazyFnHashInit ?? throw new ArgumentNullException(nameof(lazyFnHashInit));

        this._lazyFnHashInit.Init(
            ref this._fnDelHash,
            ref this._gptFnHash,
            ref this._fnDefHash
        );
    }

    public Delegate GetFnDel(string key) => this._fnDelHash[key];
    public GptFunction GetGptFn(string key) => this._gptFnHash[key];
    public FunctionDefinition GetFnDef(string key) => this._fnDefHash[key];
}