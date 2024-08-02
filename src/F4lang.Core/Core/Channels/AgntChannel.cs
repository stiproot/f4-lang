
namespace F4lang.Core;

public class AgntChannel
{
    private readonly IList<IAgntEvt> _evts = new List<IAgntEvt>();

    public delegate Task StateChangeHandler(IAgntEvt agntEvt);
    public event StateChangeHandler? StateChanged;

    public AgntChannel PushEvt(IAgntEvt agntEvt)
    {
        this._evts.Add(agntEvt);
        this.OnStateChanged(agntEvt);
        
        return this;
    }

    protected virtual void OnStateChanged(IAgntEvt agntEvt)
    {
        StateChanged?.Invoke(agntEvt).Wait();
    }
}
