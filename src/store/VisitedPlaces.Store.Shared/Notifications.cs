using MediatR;

namespace VisitedPlaces.Store.Shared;

public record NewPlaceAddedNotification(Guid userId, Guid placeId) : INotification;
