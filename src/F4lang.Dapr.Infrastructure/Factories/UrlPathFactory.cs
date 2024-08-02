
namespace F4lang.Dapr.Infrastructure.Factories;

public static class UrlPathFactory
{
    public static string CreateAgntMetadataPath(string agntId) => $"agnt/{agntId}";
}