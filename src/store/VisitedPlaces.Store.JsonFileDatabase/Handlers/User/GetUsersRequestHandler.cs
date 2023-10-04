using VisitedPlaces.Store.Shared.Models;
using VisitedPlaces.Store.Shared;
using MediatR;

namespace VisitedPlaces.Store.JsonFileDatabase.Handlers;

public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, IEnumerable<User>>
{
    public async Task<IEnumerable<User>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        await Task.Delay(0);
        return new User[] { new User(Guid.NewGuid(), "Example ") };
    }
}