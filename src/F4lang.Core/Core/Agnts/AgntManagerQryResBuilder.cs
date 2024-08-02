
namespace F4lang.Core.Agnts;

public class AgntManagerQryResBuilder : IAgntManagerQryResBuilder
{
    private string? _rawTxtRes;
    private AgntChat? _agntChat;
    private AgntQryResStatus _status;
    private object? _callbackRes;

    public IAgntManagerQryResBuilder SetRawTxtRes(string? res)
    {
        this._rawTxtRes = res;
        return this;
    }

    public IAgntManagerQryResBuilder SetAgntChat(AgntChat? agntChat)
    {
        this._agntChat = agntChat;
        return this;
    }

    public IAgntManagerQryResBuilder SetStatus(AgntQryResStatus status)
    {
        this._status = status;
        return this;
    }

    public IAgntManagerQryResBuilder SetCallbackRes(object? callbackRes)
    {
        this._callbackRes = callbackRes;
        return this;
    }

    public IAgntManagerQryRes Build()
    {
        return new AgntManagerQryRes
        {
            RawTxtRes = this._rawTxtRes,
            AgntChat = this._agntChat,
            Status = this._status,
            CallbackRes = this._callbackRes
        };
    }
}