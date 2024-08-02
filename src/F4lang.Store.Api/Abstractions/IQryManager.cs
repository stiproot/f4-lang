
namespace F4lang.Store.Api.Abstractions;

public interface IQryManager
{
  Task<IEnumerable<TResult>> ManageAsync<TResult>(IQry qry);
}
