using Microsoft.SemanticKernel.Memory;

#pragma warning disable SKEXP0003, SKEXP0001

namespace F4lang.Core;

public sealed class EmptyAgntMemory : IAgntMemory
{
    public ISemanticTextMemory Memory => throw new NotSupportedException();

    public async Task<IEnumerable<IAgntMemoryQryRes>> SearchAsync(IAgntMemoryQry qry)
    {
        await Task.CompletedTask;
        throw new NotSupportedException();
    }
}