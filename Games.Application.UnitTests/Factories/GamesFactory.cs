using System;
using System.Collections.Generic;
using Games.Application.Models.Entities;

namespace Games.Application.UnitTests.Factories;

public static class GamesFactory
{
    private static readonly Random Random = new();

    public static Game CreateRandomGame()
    {
        long number = Random.NextInt64();
        return new Game
        {
            Name = $"Game {number}",
            Developer = $"Developer {number}",
            Genres = new[] { $"Genre {number}" }
        };
    }

    public static IEnumerable<Game> CreateRandomGames(int number = 5)
    {
        var result = new List<Game>();

        for (int i = 0; i < number; i++)
        {
            result.Add(CreateRandomGame());
        }

        return result;
    }
}
