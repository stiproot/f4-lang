
namespace F4lang.Core.Abstractions;

public interface IAgntManagerQry
{
    string QryUid { get; init; }
    string RawTxtQry { get; init; }
    IList<IFnBuilder> JitFns { get; init; }
}