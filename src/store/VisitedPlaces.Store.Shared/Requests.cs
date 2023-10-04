using VisitedPlaces.Store.Shared.Models;
using MediatR;

namespace VisitedPlaces.Store.Shared;

public record GetUsersRequest() : IRequest<IEnumerable<User>>;
public record GetVisitedPlacesRequest(Guid userId) : IRequest<IEnumerable<Place>>;
public record AddNewVisitedPlace(Guid userId, Guid placeId) : IRequest;

public record GetPlacesRequest() : IRequest<IEnumerable<Place>>;
public record GetVisitorsForPlaceRequest(Guid placeId) : IRequest<IEnumerable<User>>;

