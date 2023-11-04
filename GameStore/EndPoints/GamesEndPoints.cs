using GameStore.Entities;
using GameStore.Repositories;

namespace GameStore.EndPoints;

public static class GamesEndPoints
{
    const string GetGameEndPointName = "GetGame";


    public static RouteGroupBuilder MapGamesEndPoints(this IEndpointRouteBuilder routse)
    {


        var group = routse.MapGroup("/games")
                            .WithParameterValidation();


        group.MapGet("/", (IGamesRepository repository) => repository.GetAll());

        group.MapGet("/{id}", (IGamesRepository repository, int id) =>
        {
            Game? game = repository.Get(id);

            return game is not null ? Results.Json(game) : Results.NotFound();
        });

        group.MapPost("/", (IGamesRepository repository, Game game) =>
        {
            repository.Create(game);
            return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id, }, game);
        });

        group.MapPut("/{id}", (int id, Game updatedGame, IGamesRepository repository) =>
        {
            Game? existingGame = repository.Get(id);

            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Price = updatedGame.Price;
            existingGame.ReliseDate = updatedGame.ReliseDate;
            existingGame.ImageUrl = updatedGame.ImageUrl;

            repository.Update(updatedGame);

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (IGamesRepository repository, int id) =>
        {
            Game? game = repository.Get(id);

            if (game is not null)
                repository.Delete(id);

            return Results.Json(game);

        });


        return group;
    }
}