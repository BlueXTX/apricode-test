using System.Threading.Tasks;
using FluentAssertions;
using Games.Application.Interfaces;
using Games.Application.Models.Entities;
using Games.Application.Services;
using Games.Application.UnitTests.Factories;
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
}
