
namespace F4lang.Store.Api.Abstractions;

public interface ICmdManager
{
  Task ManageAsync(ICmd cmd);
}
