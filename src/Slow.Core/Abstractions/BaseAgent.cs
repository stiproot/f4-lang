using Kernel = Microsoft.SemanticKernel.Kernel;

namespace Slow.Core.Abstractions;

public abstract class BaseAgent(
    IAgentConfiguration configuration,
    Kernel kernel,
    IObjMapper mapper
)
{
    protected readonly IAgentConfiguration _Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    protected readonly Kernel _Kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
    protected readonly IObjMapper _Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    protected readonly IList<string> _ChatHistory = new List<string>();

    public bool IsProcessing { get; }
    public bool IsLeader { get; }
}