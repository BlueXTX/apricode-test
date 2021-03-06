using System.Threading.Tasks;
using FluentAssertions;
using Games.Application.Interfaces;
using Games.Application.Models.Entities;
using Games.Application.Services;
using Games.Application.UnitTests.Factories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Games.Application.UnitTests.Tests;

public class GamesServiceTests
{
    private readonly IApplicationContext _context;

    public GamesServiceTests(IApplicationContext context)
    {
        _context = context;
    }

    [Fact]
    private async Task CreateGameAsyncTest()
    {
        var service = new GamesService(_context);
        var game = GamesFactory.CreateRandomGame();

        var gameInDb = await service.CreateGameAsync(game);
        game.Id = gameInDb.Id;

        _context.Games.Should().OnlyContain(x => x == game);
    }

    [Fact]
    private async Task GetGamesByGenreAsync()
    {
        var notSuitableGames = GamesFactory.CreateRandomGames();
        string suitableGenre = "Survival";
        var expected = new Game[]
        {
            new()
            {
                Name = "Test 1", Developer = "Developer 1", Genres = new[] { suitableGenre }
            },
            new()
            {
                Name = "Test 1", Developer = "Developer 1",
                Genres = new[] { "Horror", suitableGenre }
            },
            new()
            {
                Name = "Test 1", Developer = "Developer 1",
                Genres = new[] { suitableGenre, "Shooter" }
            }
        };

        await _context.Games.AddRangeAsync(notSuitableGames);
        await _context.Games.AddRangeAsync(expected);
        await _context.SaveChangesAsync();

        var service = new GamesService(_context);

        var actual = await service.GetGamesByGenreAsync(suitableGenre);

        actual.Should().Contain(expected).And.HaveCount(expected.Length);
    }

    [Fact]
    private async Task UpdateGameAsyncTest()
    {
        var randomGame = GamesFactory.CreateRandomGame();
        var gameInDb = (await _context.Games.AddAsync(randomGame)).Entity;

        await _context.SaveChangesAsync();
        var expected = GamesFactory.CreateRandomGame();
        expected.Id = gameInDb.Id;

        var service = new GamesService(_context);
        var actual = await service.UpdateGameAsync(gameInDb.Id, expected);

        expected.Should().BeEquivalentTo(actual);
    }

    [Fact]
    private async Task DeleteGameAsyncTest()
    {
        var game = GamesFactory.CreateRandomGame();
        game.Id = (await _context.Games.AddAsync(game)).Entity.Id;
        await _context.SaveChangesAsync();

        var service = new GamesService(_context);
        await service.DeleteGameAsync(game.Id);

        _context.Games.Should().NotContain(game);
    }
}
