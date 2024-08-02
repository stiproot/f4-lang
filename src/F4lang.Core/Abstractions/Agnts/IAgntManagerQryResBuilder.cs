
namespace F4lang.Core.Abstractions;

public interface IAgntManagerQryResBuilder
{
    IAgntManagerQryResBuilder SetRawTxtRes(string? res);
    IAgntManagerQryResBuilder SetAgntChat(AgntChat? agntChat);
    IAgntManagerQryResBuilder SetStatus(AgntQryResStatus status);
    IAgntManagerQryResBuilder SetCallbackRes(object? callbackRes);
    IAgntManagerQryRes Build();
}
