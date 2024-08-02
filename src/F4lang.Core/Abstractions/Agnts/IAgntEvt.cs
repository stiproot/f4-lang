
namespace F4lang.Core.Abstractions;

public interface IAgntEvt
{
    string SrcAgnt { get; init; }
    AgntChat? AgntChat { get; init; }
}