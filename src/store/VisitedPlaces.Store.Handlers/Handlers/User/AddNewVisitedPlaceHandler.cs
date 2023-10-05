using VisitedPlaces.Store.Shared.Models;
using VisitedPlaces.Store.Shared;
using MediatR;

namespace VisitedPlaces.Store.Handlers;

public class AddNewVisitedPlaceHandler : IRequestHandler<AddNewVisitedPlace>
{
    private readonly IMediator _mediator;

    public AddNewVisitedPlaceHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(AddNewVisitedPlace request, CancellationToken cancellationToken)
    {
        await _mediator.Publish(new NewPlaceAddedNotification(request.userId, request.placeId));
    }
}