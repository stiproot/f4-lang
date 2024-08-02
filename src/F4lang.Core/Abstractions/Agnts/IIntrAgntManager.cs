
namespace F4lang.Core.Abstractions;

public interface IIntrAgntManager : IAgntManager
{
    IAgntManager SetChannel(AgntChannel agntChannel);
    Task HandleChannelEvt(IAgntEvt agntEvt);
    IAgntManager SetAgntManagerHash(IAgntManagerHash agntManagerHash);
}