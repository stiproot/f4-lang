namespace Slow.Core.Models;

public sealed record ModelOptions
{
    public string Type { get; init; } = "azure";
    public string Model{ get; init; } = "gpt-4-32k";
    public string Endpoint { get; init; } = "";
    public string ApiKey { get; init; } = "";
    public string Org { get; init; } = string.Empty;
    public bool UseAzureOpenAI => this.Type == "azure";
}