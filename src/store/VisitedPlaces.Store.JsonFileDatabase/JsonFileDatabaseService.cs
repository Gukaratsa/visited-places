using Microsoft.Extensions.Options;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using VisitedPlaces.Shared;
using VisitedPlaces.Store.JsonFileDatabase.Models;
using VisitedPlaces.Store.Shared.Interfaces;
using VisitedPlaces.Store.Shared.Models;

namespace VisitedPlaces.Store.JsonFileDatabase;

public class JsonFileDatabaseServiceOptions
{
    public string DatabaseFolder { get; set; } = "Data";
    public string UserFolder { get; set; } = "Users";
    public string PlaceFolder { get; set; } = "Places";
    public string LinkFolder { get; set; } = "Links";
    public string UserPlaceLinkFileName { get; set; } = "UserPlacesLink.json";

    public string FullDatabaseFolder => Path.Combine(Common.ExePath, DatabaseFolder);
    public string FullUsersFolder => Path.Combine(FullDatabaseFolder, UserFolder);
    public string FullPlacesFolder => Path.Combine(FullDatabaseFolder, PlaceFolder);
    public string FullLinksFolder => Path.Combine(FullDatabaseFolder, LinkFolder);
    public string FullUserPlaceLinkFileName => Path.Combine(FullLinksFolder, UserPlaceLinkFileName);
}

public class JsonFileDatabaseService : IDatabaseService
{
    private readonly JsonFileDatabaseServiceOptions _options;

    public JsonFileDatabaseService() 
    {
        _options = new();
    }

    public JsonFileDatabaseService(IOptions<JsonFileDatabaseServiceOptions> options)
    {
        _options = options.Value;
    }

    public async Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken = default(CancellationToken))
    {
        var files = Directory.GetFiles(_options.FullUsersFolder, "*.json");
        var result = new List<User>();
        foreach (var file in files)
        {
            var fileStream = File.OpenRead(file);
            var user = await JsonSerializer.DeserializeAsync<User>(fileStream, cancellationToken: cancellationToken);
            if (user is not null)
                result.Add(user);
        }
        return result;
    }

    public async Task<IEnumerable<Place>> GetVisitedPlaces(Guid userId, CancellationToken cancellationToken = default(CancellationToken))
    {
        using var fileStream = File.OpenRead(_options.FullUserPlaceLinkFileName);
        var userPlaceLinks = await JsonSerializer.DeserializeAsync<UserPlaceLink>(fileStream, cancellationToken: cancellationToken);
        if (userPlaceLinks is null)
            throw new ArgumentNullException($"No links found from '{_options.FullUserPlaceLinkFileName}'");

        var userLinks = userPlaceLinks.Links.FirstOrDefault(x => x.Value.User == userId);
        if (userLinks.Key == new Guid())
            return new Place[0];

        var result = new List<Place>();
        foreach(var placeId in userLinks.Value.Places)
        {
            var file = Path.Combine(_options.FullPlacesFolder, $"{placeId}.json");
            if(!File.Exists(file))
                throw new ArgumentNullException($"No place file found for '{placeId}' from '{_options.FullPlacesFolder}'");

            using var fileStream_place = File.OpenRead(file);
            var place = await JsonSerializer.DeserializeAsync<Place>(fileStream_place, cancellationToken: cancellationToken);
            if (place is not null)
                result.Add(place);
        }
        return result;
    }

    public async Task<IEnumerable<Place>> GetPlaces(CancellationToken cancellationToken = default(CancellationToken))
    {
        var files = Directory.GetFiles(_options.FullPlacesFolder, "*.json");
        var result = new List<Place>();
        foreach (var file in files)
        {
            var fileStream = File.OpenRead(file);
            var place = await JsonSerializer.DeserializeAsync<Place>(fileStream, cancellationToken: cancellationToken);
            if (place is not null)
                result.Add(place);
        }
        return result;
    }

    public async Task<IEnumerable<User>> GetVisitors(Guid placeId, CancellationToken cancellationToken = default(CancellationToken))
    {
        var fileStream = File.OpenRead(_options.FullUserPlaceLinkFileName);
        var userPlaceLinks = await JsonSerializer.DeserializeAsync<UserPlaceLink>(fileStream, cancellationToken: cancellationToken);
        if (userPlaceLinks is null)
            throw new ArgumentNullException($"No links found from '{_options.FullUserPlaceLinkFileName}'");

        var placeLinks = userPlaceLinks.Links.Where(x => x.Value.Places.Contains(placeId));
        if (placeLinks is null || placeLinks.Count() == 0)
            return new User[0];

        var result = new List<User>();
        foreach (var place in placeLinks)
        {
            var userId = place.Value.User;
            var file = Path.Combine(_options.FullUsersFolder, $"{userId}.json");
            if (!File.Exists(file))
                throw new ArgumentNullException($"No user file found for '{userId}' from '{_options.FullUsersFolder}'");

            using var fileStream_place = File.OpenRead(file);
            var user = await JsonSerializer.DeserializeAsync<User>(fileStream_place, cancellationToken: cancellationToken);
            if (user is not null)
                result.Add(user);
        }
        return result;
    }
}
