using Microsoft.Extensions.Options;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using VisitedPlaces.Shared;
using VisitedPlaces.Store.Shared.Interfaces;
using VisitedPlaces.Store.Shared.Models;

namespace VisitedPlaces.Store.JsonFileDatabase;

public class JsonFileDatabaseServiceOptions
{
    public string DatabaseFolder { get; set; } = "Data";
    public string UserFolder { get; set; } = "Users";
    public string PlaceFolder { get; set; } = "Places";

    public string FullDatabaseFolder => Path.Combine(Common.ExePath, DatabaseFolder);
    public string FullUsersFolder => Path.Combine(FullDatabaseFolder, UserFolder);
    public string FullPlacesFolder => Path.Combine(FullDatabaseFolder, PlaceFolder);
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
}
