using VisitedPlaces.Store.Shared.Models;
using VisitedPlaces.Store.Shared;
using MediatR;
using VisitedPlaces.Store.Shared.Interfaces;

namespace VisitedPlaces.Store.SQLiteDatabase.Handlers;

public class GetVisitedPlacesRequestHandler : IRequestHandler<GetVisitedPlacesRequest, IEnumerable<Place>>
{
    private readonly IDatabaseService _databaseService;

    public GetVisitedPlacesRequestHandler(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }
    public Task<IEnumerable<Place>> Handle(GetVisitedPlacesRequest request, CancellationToken cancellationToken)
    {
        return _databaseService.GetPlaces(cancellationToken);
    }
}