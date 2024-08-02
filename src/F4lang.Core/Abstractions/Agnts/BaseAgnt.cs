
namespace F4lang.Core.Abstractions;

public abstract class BaseAgnt
{
    protected static IAgntQryRes EndProcess(AgntQryResStatus agntQryResStatus = AgntQryResStatus.COMPLETE)
        => new AgntQryRes { RawTxtRes = "End of conversation.", Status = agntQryResStatus };
}