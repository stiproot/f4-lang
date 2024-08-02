
namespace F4lang.Core.Models;

public record AgntManagerQry : IAgntManagerQry
{
    public string QryUid { get; init; } = string.Empty;
    public string RawTxtQry { get; init; } = string.Empty;
    public IList<IFnBuilder> JitFns { get; init; } = [];
}