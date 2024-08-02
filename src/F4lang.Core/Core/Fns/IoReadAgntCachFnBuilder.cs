namespace F4lang.Core;

public class IoReadAgntCacheFnBuilder(IAgntCache agntCache) : IFnBuilder
{
    private readonly IAgntCache _agntCache = agntCache ?? throw new ArgumentNullException(nameof(agntCache));
    public string Key => FnNames.IO_READ_AGENT_CACHE;

    public Delegate Build()
    {
        return (string agntId) => 
        {
            Console.WriteLine($"Invoking function: {Key}");
            return this._agntCache.GetAgntChat(agntId)?.Build();
        };
    }
}