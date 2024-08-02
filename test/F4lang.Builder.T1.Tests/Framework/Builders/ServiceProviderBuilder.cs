using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using F4lang.Core.Extensions;
using F4lang.Dapr.Actors.Extensions;
using F4lang.Dapr.Infrastructure.Extensions;

namespace F4lang.Builder.T1.Tests.Framework.Builders;

[ExcludeFromCodeCoverage]
internal class ServiceProviderBuilder : IServiceProviderBuilder
{
  private readonly IObjFactory<IServiceCollection> _serviceCollectionFactory = new ServiceCollectionFactory();
  private readonly IFactory<IConfiguration> _configurationFactory = new ConfigurationFactory();
  private readonly IConfiguration _configuration;
  private IServiceCollection _serviceCollection;

  public ServiceProviderBuilder()
  {
    this._configuration = this._configurationFactory.Create();

    this._serviceCollection =
      _serviceCollectionFactory.Create();

    this._serviceCollection.AddLogging(builder => builder.AddConsole());

    this._serviceCollection.AddSingleton(this._configuration);

    // _serviceCollection.AddSingleton<IOptions<FoghornSettings>>(_optionsFactory.Create());
  }

  public IServiceProviderBuilder AddAll()
  {
    return this
      .AddTestServices()
      .AddMockedServices()
      .AddSlowModules();
  }

  public IServiceProviderBuilder AddMockedServices()
  {
    this._serviceCollection.AddMockedServices();
    return this;
  }
  
  public IServiceProviderBuilder AddTestServices()
  {
    this._serviceCollection.AddTestServices();
    return this;
  }

  public IServiceProviderBuilder AddSlowModules()
  {
    this._serviceCollection.AddAllSlowServices(this._configuration);
    this._serviceCollection.AddSlowDaprActorServices(this._configuration);
    this._serviceCollection.AddSlowDaprInfrastructureServices();
    this._serviceCollection.AddSlowBuilderServices();

    return this;
  }

  public IServiceProvider Build()
    => _serviceCollection.BuildServiceProvider();
}
