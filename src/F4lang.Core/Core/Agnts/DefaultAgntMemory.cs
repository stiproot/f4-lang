using Microsoft.SemanticKernel.Memory;

#pragma warning disable SKEXP0003, SKEXP0001

namespace F4lang.Core;

public sealed class DefaultAgntMemory(
    ISemanticTextMemory memory, 
    IObjMapper objMapper
) : IAgntMemory
{
    private readonly IObjMapper _objMapper = objMapper ?? throw new ArgumentNullException(nameof(objMapper));
    private readonly ISemanticTextMemory _memory = memory ?? throw new ArgumentNullException(nameof(memory));

    private IAgntMemoryQryRes Map(MemoryQueryResult res)
    {
        return this._objMapper.Map<MemoryQueryResult, AgntMemoryQryRes>(res);
    }

    public ISemanticTextMemory Memory => this._memory;

    public async Task<IEnumerable<IAgntMemoryQryRes>> SearchAsync(IAgntMemoryQry qry)
    {
        IList<IAgntMemoryQryRes> output = [];

        var res = this._memory.SearchAsync(qry.Collection, qry.Qry);

        await foreach(var r in res)
        {
            output.Add(this.Map(r));
        }

        return output;
    }
}