
using System.ComponentModel.DataAnnotations;

namespace F4lang.Store.Api.Models;

public record QryAgntPoolReq : IReq
{
    [Required]
    public string UsrQry { get; init; } = string.Empty;
}