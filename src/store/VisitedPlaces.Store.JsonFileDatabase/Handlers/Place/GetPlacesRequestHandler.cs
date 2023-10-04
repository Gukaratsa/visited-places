using VisitedPlaces.Store.Shared.Models;
using VisitedPlaces.Store.Shared;
using MediatR;

namespace VisitedPlaces.Store.JsonFileDatabase.Handlers;

public class GetPlacesRequestHandler : IRequestHandler<GetPlacesRequest, IEnumerable<Place>>
{
    public async Task<IEnumerable<Place>> Handle(GetPlacesRequest request, CancellationToken cancellationToken)
    {
        await Task.Delay(0);
        return new Place[] { new Place(Guid.NewGuid(), "Example ") };
    }
}