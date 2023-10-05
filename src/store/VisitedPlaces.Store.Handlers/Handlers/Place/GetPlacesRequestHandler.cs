using VisitedPlaces.Store.Shared.Interfaces;
using VisitedPlaces.Store.Shared.Models;
using VisitedPlaces.Store.Shared;
using MediatR;

namespace VisitedPlaces.Store.Handlers;

public class GetPlacesRequestHandler : IRequestHandler<GetPlacesRequest, IEnumerable<Place>>
{
    private readonly IDatabaseService _databaseService;

    public GetPlacesRequestHandler(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public Task<IEnumerable<Place>> Handle(GetPlacesRequest request, CancellationToken cancellationToken)
    {
        return _databaseService.GetPlaces(cancellationToken);
    }
}