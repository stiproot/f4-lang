
namespace F4lang.Core.Abstractions;

public interface IAgntManagerRuntimeConfig
{
    IList<IFnBuilder> JitFns { get; init; }
}