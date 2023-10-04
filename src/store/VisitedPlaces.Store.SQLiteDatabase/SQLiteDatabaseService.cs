using Microsoft.Extensions.Options;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using VisitedPlaces.Shared;
using VisitedPlaces.Store.Shared.Interfaces;
using VisitedPlaces.Store.Shared.Models;

namespace VisitedPlaces.Store.JsonFileDatabase;

public class SQLiteDatabaseServiceOptions
{
    public string DatabaseFolder { get; set; } = "Data";
    public string DatabaseFileName { get; set; } = "database.sqitel";

    public string FullDatabaseFolder => Path.Combine(Common.ExePath, DatabaseFolder);
    public string FullDatabaseName => Path.Combine(FullDatabaseFolder, DatabaseFileName);
}

public class SQLiteDatabaseService : IDatabaseService
{
    private readonly SQLiteDatabaseServiceOptions _options;

    public SQLiteDatabaseService() 
    {
        _options = new();
    }

    public SQLiteDatabaseService(IOptions<SQLiteDatabaseServiceOptions> options)
    {
        _options = options.Value;
    }

    public async Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken = default(CancellationToken))
    {
        var result = new List<User>();
       
        return result;
    }

    public async Task<IEnumerable<Place>> GetPlaces(CancellationToken cancellationToken = default(CancellationToken))
    {
        var result = new List<Place>();
       
        return result;
    }
}
