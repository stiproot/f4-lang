using Microsoft.SemanticKernel.Memory;

#pragma warning disable SKEXP0003

namespace Slow.Core;

public sealed class AgentMemory(
    ISemanticTextMemory memory, 
    IObjMapper objMapper
) : IAgentMemory
{
    private readonly IObjMapper _objMapper = objMapper ?? throw new ArgumentNullException(nameof(objMapper));
    // private readonly IEnumerable<ISemanticTextMemory> _memories = new List<ISemanticTextMemory>();
    private readonly ISemanticTextMemory _memory = memory ?? throw new ArgumentNullException(nameof(memory));
    // todo: how does collection get set?
    private readonly string Collection = "mermaid";

    // todo: complete mapping logic...
    private IAgentMemoryQryRes Map(MemoryQueryResult res) => this._objMapper.Map<MemoryQueryResult, AgentMemoryQryRes>(res);

    public ISemanticTextMemory Memory => this._memory;

    public async Task<IEnumerable<IAgentMemoryQryRes>> SearchAsync(IAgentMemoryQry qry)
    {
        IList<IAgentMemoryQryRes> output = new List<IAgentMemoryQryRes>();

        // foreach(var m in this._memories)
        // {
        //     var res = m.SearchAsync(Collection, qry.Ql);

        //     await foreach(var r in res)
        //     {
        //         output.Add(this.Map(r));
        //     }
        // }

        // foreach(var m in this._memories)
        // {
        var res = this._memory.SearchAsync(Collection, qry.Qry);

        await foreach(var r in res)
        {
            output.Add(this.Map(r));
        }

        // }

        return output;
    }
}