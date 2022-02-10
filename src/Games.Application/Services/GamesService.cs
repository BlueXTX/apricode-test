using Games.Application.Interfaces;
using Games.Application.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Games.Application.Services;

public class GamesService : IGamesService
{
    private readonly IApplicationContext _context;

    public GamesService(IApplicationContext context)
    {
        _context = context;
    }

    public async Task<Game> CreateGameAsync(Game game)
    {
        var result = await _context.Games.AddAsync(game);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<IEnumerable<Game>> GetGamesByGenreAsync(string genre)
    {
        return await _context.Games
            .Where(x => x.Genres.Contains(genre, StringComparer.InvariantCultureIgnoreCase))
            .ToListAsync();
    }

    public async Task<Game?> UpdateGameAsync(int id, Game game)
    {
        var gameInDb = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
        if (gameInDb == null) return null;

        gameInDb.Name = game.Name;
        gameInDb.Developer = game.Developer;
        gameInDb.Genres = game.Genres;
        await _context.SaveChangesAsync();
        return gameInDb;
    }

    public async Task DeleteGameAsync(int id)
    {
        var game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
        if (game == default) return;
        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
    }
}
