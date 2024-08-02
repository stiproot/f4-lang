
using Microsoft.Extensions.Logging;

namespace F4lang.Core;

public class AgntManagerQryMapper(ILogger<AgntManagerQryMapper> logger) : IAgntManagerQryMapper
{
    private readonly ILogger<AgntManagerQryMapper> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public IAgntManagerQry MapResToQry(IAgntManagerQryRes qryRes)
    {
        // this._logger.LogInformation($"AgntManagerQryMapper.Map: qryRes: {qryRes.AgntChat.Build()}");

        return new AgntManagerQry
        {
            RawTxtQry = qryRes.AgntChat!.BuildUsrChatHistory()
        };
    }
}