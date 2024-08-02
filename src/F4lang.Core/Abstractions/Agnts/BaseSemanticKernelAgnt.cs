
using Kernel = Microsoft.SemanticKernel.Kernel;

namespace F4lang.Core.Abstractions;

public abstract class BaseSemanticKernelAgnt(Kernel kernel) : BaseAgnt
{
    protected readonly Kernel _Kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
}