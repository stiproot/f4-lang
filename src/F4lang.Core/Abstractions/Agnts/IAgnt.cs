
namespace F4lang.Core.Abstractions;

public interface IAgnt
{
    IAgnt Configure();
    Task<IAgntQryRes> ProcessQryAsync(IAgntQry qry);
}