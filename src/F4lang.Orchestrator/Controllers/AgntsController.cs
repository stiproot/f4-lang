using Dapr;
using Dapr.Actors.Client;
using Dapr.Actors;
using Microsoft.AspNetCore.Mvc;
using F4lang.Core;
using System.ComponentModel.DataAnnotations;
using System.Net;
using F4lang.Core.Models;

namespace F4lang.Orchestrator.Controllers;

/// <summary>
/// Handles and executes incoming action messages.
/// </summary>
/// <seealso cref="ControllerBase" />
[ApiController]
[Route("")]
public class AgntsController : ControllerBase
{
    private readonly ILogger<AgntsController> _logger;
    private readonly IActorProxyFactory _actorProxyFactory;

    public AgntsController(
        ILogger<AgntsController> logger,
        IActorProxyFactory actorProxyFactory
    )
    {
        this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this._actorProxyFactory = actorProxyFactory ?? throw new ArgumentNullException(nameof(actorProxyFactory));
    }

    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    // [Topic("pubsub", "agnts/qrys")]
    [HttpPost("agnts/qrys")]
    public async Task<IActionResult> QueryAgntAsync(
        [Required][FromBody] Evt evt,
        CancellationToken cancellationToken = default
    )
    {
        this._logger.LogInformation($"agnts/qrys: {evt.EvtData}");

        var data = evt.DeserializeData();

        this._logger.LogInformation($"agnts/qrys: agnt-id: {data.AgntId}");

        var proxy = this._actorProxyFactory.CreateActorProxy<ICoderAgntActor>(new ActorId(data.AgntId), nameof(CoderAgntActor));

        this._logger.LogInformation("Configuring actor proxy...");

        await proxy.InitAsync(cancellationToken);

        this._logger.LogInformation("Invoking actor proxy...");

        var response = await proxy.ActAsync(new ActorCmd().Init(new AgntManagerQry { RawTxtQry = data.AgntManagerQry }));

        return Ok(response);
    }
}

            // @this.MapPost("/pubsub", 
            //     [Topic("pubsub", "agnt_qry")] async ([Required][FromBody] PubSubMsg pubSubMsg,
            //     ILogger<DaprEndpointLogger> logger,
            //     IDaprAdaptor daprAdaptor
            // ) =>
            // {
            //     logger.LogInformation($"Received pubsub message: {pubSubMsg.Details}");
            //     await daprAdaptor.DaprClient.SaveStateAsync("actorstate", pubSubMsg.ConvertMetadata().Id, pubSubMsg.Details);

            //     var msg = JsonSerializer.Serialize(pubSubMsg);

            //     logger.LogInformation($"Publishing to router: {msg}");

            //     await daprAdaptor.DaprClient.PublishEventAsync("pubsub", "route_qry", msg);

            //     // var state = await daprAdaptor.DaprClient.GetStateAsync<string>("actorstate", pubSubMsg.Metadata.Id);
            //     logger.LogInformation("Published to router");
            // });

            // @this.MapPost("/route", 
            //     [Topic("pubsub", "route_qry")] async ([Required][FromBody] PubSubMsg2 pubSubMsg,
            //     ILogger<DaprEndpointLogger> logger,
            //     IDaprAdaptor daprAdaptor
            // ) =>
            // {
            //     logger.LogInformation($"route: msg: {pubSubMsg.Data}");

            //     var data = JsonSerializer.Deserialize<PubSubMsg>(pubSubMsg.Data);
            //     var metadata = JsonSerializer.Deserialize<Metadata>(data!.Metadata);

            //     await daprAdaptor.DaprClient.SaveStateAsync("actorstate", metadata.Id, data.Details);
            //     var state = await daprAdaptor.DaprClient.GetStateAsync<string>("actorstate", metadata.Id);
            //     Console.WriteLine($"Final state: {state}");
            // });