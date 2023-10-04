using VisitedPlaces.Store.Shared.Models;
using VisitedPlaces.Store.Shared;
using MediatR;

namespace VisitedPlaces.Store.SQLiteDatabase.Handlers;

public class GetVisitorsForPlaceRequestHandler : IRequestHandler<GetVisitorsForPlaceRequest, IEnumerable<User>>
{
    public async Task<IEnumerable<User>> Handle(GetVisitorsForPlaceRequest request, CancellationToken cancellationToken)
    {
        await Task.Delay(0);
        return new User[] { new User(Guid.NewGuid(), "Example ") };
    }
}