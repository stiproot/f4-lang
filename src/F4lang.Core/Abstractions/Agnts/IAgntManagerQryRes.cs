
namespace F4lang.Core.Abstractions;

public interface IAgntManagerQryRes
{
    string? RawTxtRes { get; init; }
    AgntChat? AgntChat { get; init; }
    AgntQryResStatus Status { get; init; }
    object? CallbackRes { get; init; }
}