
using Dapr.Client;

namespace F4lang.Dapr.Infrastructure;

public class DaprAdaptor : IDaprAdaptor
{
    private readonly DaprClient _daprClient;

    public DaprAdaptor(DaprClient daprClient)
    {
        this._daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
    }

    public DaprClient DaprClient => this._daprClient;
}
