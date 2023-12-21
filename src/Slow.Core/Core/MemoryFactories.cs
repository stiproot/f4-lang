using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.Chroma;
using Microsoft.SemanticKernel.Memory;
using Kernel = Microsoft.SemanticKernel.Kernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.CodeAnalysis.CSharp.Syntax;

#pragma warning disable SKEXP0011, SKEXP0022, SKEXP0052, SKEXP0003

namespace Slow.Core;

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

        if (this._options.UseAzureOpenAI)
        {
            memoryBuilder.WithAzureOpenAITextEmbeddingGeneration("text-embedding-ada-002", this._options.Endpoint, this._options.ApiKey, "model-id");
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