using Microsoft.SemanticKernel.Memory;

#pragma warning disable SKEXP0003

namespace Slow.Core;

public sealed class EmptyAgentMemory : IAgentMemory
{
    public ISemanticTextMemory Memory => throw new NotSupportedException();

    public async Task<IEnumerable<IAgentMemoryQryRes>> SearchAsync(IAgentMemoryQry qry)
    {
        await Task.CompletedTask;
        throw new NotSupportedException();
    }
}