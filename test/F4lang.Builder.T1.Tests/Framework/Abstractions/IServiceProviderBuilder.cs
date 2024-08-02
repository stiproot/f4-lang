
namespace F4lang.Builder.T1.Tests.Framework.Abstractions;

internal interface IServiceProviderBuilder
{
  IServiceProviderBuilder AddAll();
  IServiceProviderBuilder AddMockedServices();
  IServiceProviderBuilder AddSlowModules();
  IServiceProvider Build();
}
