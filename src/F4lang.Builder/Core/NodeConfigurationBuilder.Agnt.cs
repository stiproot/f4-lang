
namespace F4lang.Builder.Core;

public partial class NodeConfigurationBuilder : INodeConfigurationBuilder
{
    public INodeConfigurationBuilder RuntimeFns<TFn>()
    {
        this._nodeConfiguration.FnTypes.Add(typeof(TFn));
        return this;
    }

	public INodeConfigurationBuilder AddArgEnricher(params (Type, Action<IMsg>)[] argEnrichers)
    {
        foreach (var argEnricher in argEnrichers)
        {
            this._nodeConfiguration.ArgEnrichers.Add(argEnricher);
        }

        return this;
    }

    public INodeConfigurationBuilder AddArgEnricher(Type argType, Action<IMsg> argEnricher)
    {
        this._nodeConfiguration.ArgEnrichers.Add((argType, argEnricher));
        return this;
    }

    // public INodeConfigurationBuilder AddTransitionNodeKey(string key)
    // {
    //     this._nodeConfiguration.Key = key;
    //     return this;
    // }
}
