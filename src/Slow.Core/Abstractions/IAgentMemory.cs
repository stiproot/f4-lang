using Microsoft.SemanticKernel.Memory;

#pragma warning disable SKEXP0003

namespace Slow.Core.Abstractions;

public interface IAgentMemory
{
    ISemanticTextMemory Memory { get; }
    Task<IEnumerable<IAgentMemoryQryRes>> SearchAsync(IAgentMemoryQry qry);
}