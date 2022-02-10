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
        return await _context.Games.Where(x => x.Genres.Contains(genre)).ToListAsync();
    }

    public Task<Game> UpdateGameAsync(int id, Game game)
    {
        throw new NotImplementedException();
    }

    public Task DeleteGameAsync(int id, Game game)
    {
        throw new NotImplementedException();
    }
}
