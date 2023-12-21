namespace Slow.Core.Abstractions;

public interface IAgent
{
    bool IsProcessing { get; }
    bool IsLeader { get; }

    IAgent Configure();
    Task<IAgentQryRes> ProcessQryAsync(IAgentQry qry);
    Task ProcessCmdAsync(IAgentCmd cmd);
}