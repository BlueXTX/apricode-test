using System.Threading.Tasks;
using FluentAssertions;
using Games.Application.Interfaces;
using Games.Application.Services;
using Xunit;

namespace Games.Application.UnitTests;

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
}
