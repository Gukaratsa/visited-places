using VisitedPlaces.Store.Shared.Models;

namespace VisitedPlaces.Store.Shared.Interfaces;

public interface IDatabaseService
{
    Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken);
    Task<IEnumerable<Place>> GetPlaces(CancellationToken cancellationToken);
    Task<IEnumerable<Place>> GetVisitedPlaces(Guid userId, CancellationToken cancellationToken = default);
    Task<IEnumerable<User>> GetVisitors(Guid placeId, CancellationToken cancellationToken = default);
}