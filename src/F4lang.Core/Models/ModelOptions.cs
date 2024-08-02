namespace F4lang.Core.Models;

public sealed record ModelOptions
{
    public string Type { get; init; } = "azure";
    public string Model{ get; init; } = "gpt-4-32k";
    public string Endpoint { get; init; } = string.Empty;
    public string ApiKey { get; init; } = string.Empty;
    public string Org { get; init; } = string.Empty;
    public bool UseAzureOpenAI => this.Type == "azure";
}