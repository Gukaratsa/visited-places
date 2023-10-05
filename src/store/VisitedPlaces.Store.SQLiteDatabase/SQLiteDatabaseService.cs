using Dapper;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using VisitedPlaces.Shared;
using VisitedPlaces.Store.Shared.Interfaces;
using VisitedPlaces.Store.Shared.Models;
using VisitedPlaces.Store.SQLiteDatabase.Context;

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
    private readonly DapperContext _context;

    public SQLiteDatabaseService(DapperContext context) 
    {
        _options = new();
        _context = context;
        Migrate();
    }

    public SQLiteDatabaseService(IOptions<SQLiteDatabaseServiceOptions> options, DapperContext context)
    {
        _options = options.Value;
        _context = context;
        Migrate();
    }

    private void Migrate()
    {

    }

    public void CreateDatabase(string dbName)
    {
        var query = "SELECT * FROM sys.databases WHERE name = @name";
        var parameters = new DynamicParameters();
        parameters.Add("name", dbName);
        using (var connection = _context.CreateMasterConnection())
        {
            var records = connection.Query(query, parameters);
            if (!records.Any())
                connection.Execute($"CREATE DATABASE {dbName}");
        }
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
   