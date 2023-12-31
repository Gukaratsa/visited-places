using VisitedPlaces.Shared;
using VisitedPlaces.Store.JsonFileDatabase;
using VisitedPlaces.Store.Shared.Interfaces;
using VisitedPlaces.Store.SQLiteDatabase.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR_FromExeFolder();

builder.Services.AddSingleton<IDatabaseService, JsonFileDatabaseService>();
//builder.Services.AddSingleton<IDatabaseService, SQLiteDatabaseService>();

builder.Services.AddSingleton<DapperContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
