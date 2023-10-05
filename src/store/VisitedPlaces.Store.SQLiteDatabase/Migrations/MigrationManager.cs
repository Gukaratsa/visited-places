using Microsoft.Extensions.DependencyInjection;
using VisitedPlaces.Store.JsonFileDatabase;
using Microsoft.Extensions.Hosting;
using FluentMigrator.Runner;

namespace VisitedPlaces.Store.SQLiteDatabase.Migrations;

public static class MigrationManager
{
    public static IHost MigrateDatabase(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var databaseService = scope.ServiceProvider.GetRequiredService<SQLiteDatabaseService>();
            var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            try
            {
                databaseService.CreateDatabase("DapperMigrationExample");
                migrationService.ListMigrations();
                migrationService.MigrateUp();
            }
            catch
            {
                //log errors or ...
                throw;
            }
        }
        return host;
    }
}
