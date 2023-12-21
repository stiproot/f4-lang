using Kernel = Microsoft.SemanticKernel.Kernel;

namespace Slow.Core;

public sealed class AgentFactory(
    IFactory<Kernel> kernelFactory,
    IObjMapper mapper
) : IFactory<IAgentConfiguration, IAgent>
{
    private readonly IFactory<Kernel> _KernelFactory = kernelFactory ?? throw new ArgumentNullException(nameof(kernelFactory));
    private readonly IObjMapper _Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public IAgent Create(IAgentConfiguration configuration) => new Agent(configuration, this._KernelFactory.Create(), this._Mapper);
}