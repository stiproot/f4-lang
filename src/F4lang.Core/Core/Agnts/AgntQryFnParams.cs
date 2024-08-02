namespace F4lang.Core;

public record AgntQryFnParams
{
    public string agntId { get; init; } = string.Empty;
    public string qry { get; init; } = string.Empty;
}
