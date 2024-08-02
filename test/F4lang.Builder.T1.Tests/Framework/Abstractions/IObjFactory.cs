
namespace F4lang.Builder.T1.Tests.Framework.Abstractions;

internal interface IObjFactory<out TCreated>
{
  TCreated Create();
}