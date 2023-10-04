using VisitedPlaces.Store.Shared.Models;

namespace VisitedPlaces.Store.Shared.Interfaces;

public interface IDatabaseService
{
    Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken);
    Task<IEnumerable<Place>> GetPlaces(CancellationToken cancellationToken);
}