
using Dapr.Client;
using F4lang.Dapr.Infrastructure.Consts;
using System.Text.Json;

namespace F4lang.Dapr.Actors.Gateways;

public class StoreApiGateway : IStoreApiGateway
{
    private readonly HttpClient _httpClient = DaprClient.CreateInvokeHttpClient(DaprApps.SLOW_STORE_API);

    public async Task<AgntMetadataModel> GetAgntMetadataAsync(
        string agntId,
        CancellationToken cancellationToken = default
    )
    {
        string url = UrlPathFactory.CreateAgntMetadataPath(agntId);
        var req = new HttpRequestMessage(HttpMethod.Post, url);
        var resp = await this._httpClient.SendAsync(req, cancellationToken);
        var res = await resp.Content.ReadAsStringAsync(cancellationToken);

        Console.WriteLine(res);

        resp.EnsureSuccessStatusCode();

        var model = JsonSerializer.Deserialize<IEnumerable<AgntMetadataModel>>(res);

        if(model?.Any() is false) throw new FileNotFoundException();

        return model!.First();
    }
}
