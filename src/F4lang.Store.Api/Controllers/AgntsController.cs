using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace F4lang.Store.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("")]
public class AgntsController : ControllerBase
{
    private readonly ILogger<AgntsController> _logger;
    private readonly IQryManager _qryManager;
    private readonly ICmdManager _cmdManager;

    public AgntsController(
        ILogger<AgntsController> logger,
        IQryManager qryManager,
        ICmdManager cmdManager
    )
    {
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this._qryManager = qryManager ?? throw new ArgumentNullException(nameof(qryManager));
        this._cmdManager = cmdManager ?? throw new ArgumentNullException(nameof(cmdManager));
    }

    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [HttpPost("agnts", Name = "AddAgnt")]
    public async Task<IActionResult> AddAgnt([Required][FromBody]AddAgntMetadataReq req)
    {
        var cmd = new AddAgntMetadataCmd() { Document = req };
        await this._cmdManager.ManageAsync(cmd);
        return Ok();
    }

    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [HttpGet("agnts/{agntIds}", Name = "GetAgnts")]
    public async Task<IActionResult> GetAgnts([Required][FromRoute]string agntIds)
    {
        var qry = new GetAgntQry() { Query = $"select agnts.* from agnts where agntId in [{string.Join(",", agntIds.Split(",").Select(id => $"'{id}'"))}]" };
        var res = await this._qryManager.ManageAsync<GetAgntQryRes>(qry);
        return Ok(res);
    }

    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [HttpPost("agnt")]
    public async Task<IActionResult> GetAgnt([Required][FromBody]GetAgntReq req)
    {
        this._logger.LogInformation($"GetAgnt: {req}");
        var qry = new GetAgntQry() { Query = $"select agnts.* from agnts where agntId = '{req.AgntId}'" };
        var res = await this._qryManager.ManageAsync<GetAgntQryRes>(qry);
        return Ok(res);
    }

    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [HttpPost("agnt/{agntId}", Name = "GetAgntDetails")]
    public async Task<IActionResult> GetAgntDetails([Required][FromRoute]string agntId)
    {
        this._logger.LogInformation($"GetAgntDetails: {agntId}");
        var qry = new GetAgntQry() { Query = $"select agnts.* from agnts where agntId = '{agntId}'" };
        var res = await this._qryManager.ManageAsync<GetAgntQryRes>(qry);
        return Ok(res);
    }

    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [HttpPost("agnts/pools", Name = "AddAgntPool")]
    public async Task<IActionResult> AddAgntPool([Required][FromBody]AddAgntPoolMetadataReq req)
    {
        var cmd = new AddAgntPoolCmd() { Document = req };
        await this._cmdManager.ManageAsync(cmd);
        return Created();
    }

    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [HttpGet("agnt/pools/{agntPoolId}", Name = "GetAgntPool")]
    public async Task<IActionResult> GetAgntPool([Required][FromRoute]string agntPoolId)
    {
        var qry = new GetAgntPoolQry() { Query = $"select pools.* from pools where agntPoolId = '{agntPoolId}'" };
        var res = await this._qryManager.ManageAsync<GetAgntPoolQryRes>(qry);
        return Ok(res);
    }
}