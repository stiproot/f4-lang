using Microsoft.SemanticKernel.Memory;

#pragma warning disable SKEXP0003, SKEXP0001

namespace F4lang.Core.Abstractions;

public interface IAgntMemory
{
    ISemanticTextMemory Memory { get; }
    Task<IEnumerable<IAgntMemoryQryRes>> SearchAsync(IAgntMemoryQry qry);
}