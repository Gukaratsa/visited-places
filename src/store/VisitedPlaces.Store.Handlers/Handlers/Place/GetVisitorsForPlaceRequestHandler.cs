using VisitedPlaces.Store.Shared.Models;
using VisitedPlaces.Store.Shared;
using MediatR;
using VisitedPlaces.Store.Shared.Interfaces;

namespace VisitedPlaces.Store.Handlers;

public class GetVisitorsForPlaceRequestHandler : IRequestHandler<GetVisitorsForPlaceRequest, IEnumerable<User>>
{
    private readonly IDatabaseService _databaseService;

    public GetVisitorsForPlaceRequestHandler(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public Task<IEnumerable<User>> Handle(GetVisitorsForPlaceRequest request, CancellationToken cancellationToken)
    {
        return _databaseService.GetVisitors(request.placeId, cancellationToken);
    }
}