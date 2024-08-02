using Microsoft.SemanticKernel.Memory;

#pragma warning disable SKEXP0001, SKEXP0022, SKEXP0052, SKEXP0003

namespace F4lang.Core.Extensions;

public static class SemanticTextMemoryExtensions
{
    public static IAgntMemory ToAgntMemory(this ISemanticTextMemory @this,
        IObjMapper objMapper
    )
        => new DefaultAgntMemory(@this, objMapper);
}