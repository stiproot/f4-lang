
namespace F4lang.Core.Models;

public record AgntPoolQry : AgntManagerQry
{
    public string LeadAgntId { get; init; } = string.Empty;
}