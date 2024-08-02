
using Microsoft.Extensions.Logging;

namespace F4lang.Builder.T1.Tests.Framework.Abstractions;

internal interface ILogOutput
{
  void Log();
}

public class LogOutput(ILogger<LogOutput> logger) : ILogOutput
{
  private readonly ILogger<LogOutput> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

  public void Log()
  {
    this._logger.LogInformation("Made it here.");
  }
}