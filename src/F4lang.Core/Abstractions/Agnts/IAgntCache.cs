namespace F4lang.Core.Abstractions;

public interface IAgntCache
{
    AgntChat? GetAgntChat(string agntId);
    void SetAgntChat(string agntId, AgntChat agntChat);
}