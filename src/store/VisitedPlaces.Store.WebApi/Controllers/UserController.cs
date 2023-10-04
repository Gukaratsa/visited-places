using MediatR;
using Microsoft.AspNetCore.Mvc;
using VisitedPlaces.Shared;
using VisitedPlaces.Store.Shared;
using VisitedPlaces.Store.Shared.Models;

namespace VisitedPlaces.Store.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;

    public UserController(IMediator mediator, ILogger<UserController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("GetUsers", Name = "GetUsers")]
    public async Task<IEnumerable<User>> GetUsers()
    {
        _logger.TrcEntryMessage();
        return await _mediator.Send(new GetUsersRequest());
    }

    [HttpGet("GetPlacesForUser", Name = "GetPlacesForUser")]
    public async Task<IEnumerable<Place>> GetPlacesForUser([FromQuery] Guid userId)
    {
        _logger.TrcEntryMessage();
        return await _mediator.Send(new GetVisitedPlacesRequest(userId));
    }

    [HttpGet("AddPlace", Name = "PostNewPlace")]
    public async Task<IActionResult> PostNewPlace([FromQuery] Guid userId, [FromQuery] Guid placeId)
    {
        _logger.TrcEntryMessage();
        await _mediator.Send(new AddNewVisitedPlace(userId, placeId));
        return Ok();
    }
}