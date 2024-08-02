
namespace F4lang.Core;

public record AgntEvt : IAgntEvt
{
    public string SrcAgnt { get; init; } = string.Empty;
    public AgntChat? AgntChat { get; init; }
}