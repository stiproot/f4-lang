using Microsoft.SemanticKernel;
using Kernel = Microsoft.SemanticKernel.Kernel;
using Microsoft.Extensions.Options;

namespace F4lang.Core;

public class KernelFactory(IOptions<ModelOptions> options) : IFactory<Kernel>
{
    private readonly ModelOptions _options = options.Value ?? throw new ArgumentNullException(nameof(options));

    public Kernel Create()
    {
        var builder = Kernel.CreateBuilder();

        if (this._options.UseAzureOpenAI) builder.AddAzureOpenAIChatCompletion(this._options.Model, this._options.Endpoint, this._options.ApiKey);
        else builder.AddOpenAIChatCompletion(this._options.Model, this._options.ApiKey, this._options.Org);

        var kernel = builder.Build();

        return kernel;
    }
}