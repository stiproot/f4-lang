
namespace Generic.Cb.Models;

public record CouchbaseOptions
{
    public string BaseUrl { get; set; } = string.Empty;
    public string Usrname { get; set; } = string.Empty;
    public string Pwd { get; set; } = string.Empty;
    public string DefaultBucket { get; set; } = string.Empty;
}