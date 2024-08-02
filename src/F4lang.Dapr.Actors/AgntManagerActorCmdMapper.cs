
using Microsoft.Extensions.Logging;
namespace F4lang.Dapr.Actors;
public class AgntManagerActorCmdMapper(ILogger<AgntManagerActorCmdMapper> logger) : IAgntManagerActorCmdMapper
{
    private readonly ILogger<AgntManagerActorCmdMapper> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    public ActorCmd Map(ActorRes res)
    {
        // this._logger.LogInformation($"AgntManagerQryMapper.Map: qryRes: {qryRes.AgntChat.Build()}");
        var data = res.Deserialize<AgntManagerQryRes>();
        var qry = new AgntManagerQry
        {
            RawTxtQry = data.AgntChat!.BuildUsrChatHistory()
        };
        return ActorMsgFactory.CreateCmd(qry);
    }
}