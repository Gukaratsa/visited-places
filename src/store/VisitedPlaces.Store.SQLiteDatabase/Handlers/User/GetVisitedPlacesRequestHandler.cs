using VisitedPlaces.Store.Shared.Models;
using VisitedPlaces.Store.Shared;
using MediatR;

namespace VisitedPlaces.Store.SQLiteDatabase.Handlers;

public class GetVisitedPlacesRequestHandler : IRequestHandler<GetVisitedPlacesRequest, IEnumerable<Place>>
{
    public async Task<IEnumerable<Place>> Handle(GetVisitedPlacesRequest request, CancellationToken cancellationToken)
    {
        await Task.Delay(0);
        return new Place[] { new Place(Guid.NewGuid(), "Example ") };
    }
}