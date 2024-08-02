using Microsoft.SemanticKernel.Connectors.Chroma;
using Microsoft.SemanticKernel.Memory;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.Extensions.Options;

#pragma warning disable SKEXP0001, SKEXP0022, SKEXP0052, SKEXP0003, SKEXP0010, SKEXP0050, SKEXP0020

namespace F4lang.Core;

public class MemoryFactoryWithVolatileStore(IOptions<ModelOptions> options) : IFactory<ISemanticTextMemory>
{
    private readonly ModelOptions _options = options.Value ?? throw new ArgumentNullException(nameof(options));

    public ISemanticTextMemory Create()
    {
        // var (useAzureOpenAI, model, azureEndpoint, apiKey, orgId) = Settings.LoadFromFile();

        var memoryBuilder = new MemoryBuilder();

        if (this._options.UseAzureOpenAI)
        {
            memoryBuilder.WithAzureOpenAITextEmbeddingGeneration(
                "text-embedding-ada-002",
                this._options.Endpoint, 
                this._options.ApiKey,
                "model-id");
        }
        else
        {
            memoryBuilder.WithOpenAITextEmbeddingGeneration("text-embedding-ada-002", this._options.ApiKey);
        }

        memoryBuilder.WithMemoryStore(new VolatileMemoryStore());

        var memory = memoryBuilder.Build();

        return memory;
    }
}

public class MemoryFactoryWithChromaStore(IOptions<ModelOptions> options) : IFactory<ISemanticTextMemory>
{
    private readonly ModelOptions _options = options.Value ?? throw new ArgumentNullException(nameof(options));

    public ISemanticTextMemory Create()
    {
        var memoryBuilder = new MemoryBuilder();

        var handler = new HttpClientHandler { CheckCertificateRevocationList = false };
        var client = new HttpClient(handler);

        if (this._options.UseAzureOpenAI)
        {
            memoryBuilder.WithAzureOpenAITextEmbeddingGeneration("text-embedding-ada-002", this._options.Endpoint, this._options.ApiKey, httpClient:client);
        }
        else
        {
            memoryBuilder.WithOpenAITextEmbeddingGeneration("text-embedding-ada-002", this._options.ApiKey);
        }

        var chromaMemoryStore = new ChromaMemoryStore("http://127.0.0.1:8000");

        memoryBuilder.WithMemoryStore(chromaMemoryStore);

        var memory = memoryBuilder.Build();

        return memory;
    }
}