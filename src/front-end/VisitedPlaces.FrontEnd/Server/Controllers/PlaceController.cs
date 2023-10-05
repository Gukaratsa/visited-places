using MediatR;
using Microsoft.AspNetCore.Mvc;
using VisitedPlaces.Shared;
using VisitedPlaces.Store.Shared;
using VisitedPlaces.Store.Shared.Models;

namespace VisitedPlaces.FrontEnd.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class PlaceController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;

    public PlaceController(IMediator mediator, ILogger<UserController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("GetPlaces", Name = "GetPlaces")]
    public async Task<IEnumerable<Place>> GetPlaces()
    {
        _logger.TrcEntryMessage();
        return await _mediator.Send(new GetPlacesRequest());
    }

    [HttpGet("GetVisitors", Name = "GetVisitors")]
    public async Task<IEnumerable<User>> GetVisitors([FromQuery] Guid placeId)
    {
        _logger.TrcEntryMessage();
        return await _mediator.Send(new GetVisitorsForPlaceRequest(placeId));
    }
}