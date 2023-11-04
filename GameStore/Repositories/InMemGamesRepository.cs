using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Entities;

namespace GameStore.Repositories;


public class InMemGamesRepository : IGamesRepository
{

private readonly List<Game> games = new()
{
    new Game()
    {
        Id = 1,
        Name = "GTA V",
        Genre = "Shooter",
        Price = 19.99M,
        ReliseDate = new DateTime(2015, 2,1),
        ImageUrl = "https:/placehold.co/100"
    },

    new Game()
    {
        Id = 2,
        Name = "Final Fantacy XIV",
        Genre = "Roleplaying",
        Price = 59.99M,
        ReliseDate = new DateTime(2010,9,30),
        ImageUrl = "https:/placehold.co/100"
    },
    new Game()
    {
        Id = 3,
        Name = "FiFA 23",
        Genre = "Sports",
        Price = 69.99M,
        ReliseDate = new DateTime(2022, 10,28),
        ImageUrl = "https:/placehold.co/100"
    },
};

    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    public Game? Get(int id)
    {
        return games.Find(game => game.Id == id);
    }

    public void Create(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }

    public void Delete(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
    }

}