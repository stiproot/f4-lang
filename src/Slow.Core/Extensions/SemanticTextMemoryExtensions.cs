using Microsoft.SemanticKernel.Memory;

#pragma warning disable SKEXP0011, SKEXP0022, SKEXP0052, SKEXP0003

namespace Slow.Core.Extensions;

public static class SemanticTextMemoryExtensions
{
    public static IAgentMemory ToAgentMemory(this ISemanticTextMemory @this,
        IObjMapper objMapper
    )
        => new AgentMemory(@this, objMapper);
}