
namespace F4lang.Builder.T1.Tests.Framework.Factories;

[ExcludeFromCodeCoverage]
internal class ServiceCollectionFactory : IObjFactory<IServiceCollection>
{
  public IServiceCollection Create()
    => new ServiceCollection();
}
