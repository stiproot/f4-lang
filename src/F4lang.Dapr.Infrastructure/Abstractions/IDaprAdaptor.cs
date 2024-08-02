
using Dapr.Client;

namespace F4lang.Dapr.Infrastructure.Abstractions;

public interface IDaprAdaptor
{
    DaprClient DaprClient { get; }
}
