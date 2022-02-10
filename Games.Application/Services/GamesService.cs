using Games.Application.Interfaces;
using Games.Application.Models.Entities;

namespace Games.Application.Services;

public class GamesService : IGamesService
{
    public Task<Game> CreateGameAsync(Game game)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Game>> GetGamesByGenreAsync(string genre)
    {
        throw new NotImplementedException();
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
