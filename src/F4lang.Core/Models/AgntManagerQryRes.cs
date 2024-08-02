
namespace F4lang.Core.Models;

public record AgntManagerQryRes : IAgntManagerQryRes
{
    public string? RawTxtRes { get; init; }
    public AgntChat? AgntChat { get; init; }
    public AgntQryResStatus Status { get; init; } = AgntQryResStatus.COMPLETE;
    public object? CallbackRes { get; init; }
}