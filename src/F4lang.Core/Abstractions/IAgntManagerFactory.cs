
namespace F4lang.Core.Abstractions;

public interface IAgntManagerFactory
{
    IAgntManager Create(
        IAgnt agnt,
        IAgntConfiguration configuration
    );
}
