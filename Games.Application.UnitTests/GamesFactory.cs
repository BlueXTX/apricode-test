using System;
using Games.Application.Models.Entities;

namespace Games.Application.UnitTests;

public static class GamesFactory
{
    private static readonly Random Random = new Random();

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
}
