// using Dapr.Client;

// namespace F4lang.Store.Proxy.Api.Managers;

// internal class CreatePoolManager : BaseManager, IManager<CreateAgntPoolReq, CreateAgntPoolResp>
// {
//     private readonly DaprClient _daprClient;

//     public CreatePoolManager(DaprClient daprClient) : base()
//     {
//         this._daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
//     }

//     public async Task<CreateAgntPoolResp> ManageAsync(CreateAgntPoolReq req)
//     {
//         var response = await this._daprClient.GetStateAsync<dynamic>("product-store", id);
//     }
// }
