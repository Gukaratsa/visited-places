using VisitedPlaces.Store.Shared.Models;
using VisitedPlaces.Store.Shared;
using MediatR;
using VisitedPlaces.Store.Shared.Interfaces;

namespace VisitedPlaces.Store.Handlers;

public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, IEnumerable<User>>
{
    private readonly IDatabaseService _databaseService;

    public GetUsersRequestHandler(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    public Task<IEnumerable<User>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        return _databaseService.GetUsers(cancellationToken);
    }
}