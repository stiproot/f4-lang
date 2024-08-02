
namespace F4lang.Builder.Abstractions;

public interface IServiceProviderAdaptor
{
    object? GetService(Type serviceType);
}