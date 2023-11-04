using GameStore.EndPoints;
using GameStore.Entities;
using GameStore.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGamesRepository, InMemGamesRepository>();


var app = builder.Build();

app.MapGamesEndPoints();




app.Run();