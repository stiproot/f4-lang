using Microsoft.Extensions.Configuration;

namespace F4lang.Builder.T1.Tests.Framework.Factories;

[ExcludeFromCodeCoverage]
internal class ConfigurationFactory : IFactory<IConfiguration>
{
  public IConfiguration Create()
  {
    var configBuilder =
      new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", true, true);

    return configBuilder.Build();
  }
}
