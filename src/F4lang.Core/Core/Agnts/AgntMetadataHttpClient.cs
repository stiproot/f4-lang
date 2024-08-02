
using System.Text.Json;

namespace F4lang.Core.Agnts;

public class AgntMetadataHttpClient : IAgntMetadataHttpClient
{
    string UrlPathFactory(string agntId) => $"http://localhost:5079/agnt/{agntId}";

    public async Task<AgntMetadataModel> GetAgntMetadataAsync(string agntId)
    {
        string url = UrlPathFactory(agntId);

        using HttpClient httpClient = new();

        var req = new HttpRequestMessage(HttpMethod.Post, url);
        var resp = await httpClient.SendAsync(req);
        var res = await resp.Content.ReadAsStringAsync();

        Console.WriteLine(res);

        resp.EnsureSuccessStatusCode();

        var model = JsonSerializer.Deserialize<IEnumerable<AgntMetadataModel>>(res);

        if (model?.Any() is false) throw new FileNotFoundException();

        return model!.First();
    }
}