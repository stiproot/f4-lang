using Azure.AI.OpenAI;
using Kernel = Microsoft.SemanticKernel.Kernel;

namespace F4lang.Core.Agnts;

public sealed class AgntFactory(
    IFactory<Kernel> kernelFactory,
    IObjMapper mapper,
    OpenAIClient openAIClient,
    IFnHash fnHash
) : IFactory<IAgntConfiguration, IAgnt>
{
    protected readonly IFactory<Kernel> _KernelFactory = kernelFactory ?? throw new ArgumentNullException(nameof(kernelFactory));
    protected readonly IObjMapper _Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    protected readonly OpenAIClient _OpenAIClient = openAIClient ?? throw new ArgumentNullException(nameof(openAIClient));
    protected readonly IFnHash _FnHash = fnHash ?? throw new ArgumentException(nameof(fnHash));

    public IAgnt Create(IAgntConfiguration configuration)
    {
        // var agnt = configuration.Metadata.AgntBaseType switch
        // {
        //     AgntBaseTypes.SEMANTIC_KERNEL => new DefaultSemanticKernelAgnt(configuration, this._KernelFactory.Create(), this._Mapper),
        //     AgntBaseTypes.OPEN_AI => new DefaultOpenAIAgnt(configuration, this._OpenAIClient, this._Mapper, this._FnHash),
        //     _ => throw new NotSupportedException(nameof(configuration.Metadata.AgntBaseType))
        // };

        Console.WriteLine($"AgntBaseType: {configuration.Metadata.AgntBaseType}");

        if(configuration.Metadata.AgntBaseType is AgntBaseTypes.OPEN_AI) return new DefaultOpenAIAgnt(this._OpenAIClient);

        // if(configuration.Metadata.AgntBaseType is AgntBaseTypes.SEMANTIC_KERNEL)
        // {
        //     return new DefaultSemanticKernelAgnt(configuration, this._KernelFactory.Create(), this._Mapper);
        // }

        throw new NotSupportedException(nameof(configuration.Metadata.AgntBaseType));
    }
}