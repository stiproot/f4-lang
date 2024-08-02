namespace F4lang.Core.Agnts;

public sealed class EmptyAgntCache : IAgntCache
{
    public AgntChat? GetAgntChat(string agntId) => throw new NotSupportedException();
    public void SetAgntChat(string agntId, AgntChat agntChat) => throw new NotSupportedException();
}