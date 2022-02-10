using Games.Application.Models.Entities;

namespace Games.Application.Interfaces;

public interface IGamesService
{
    public Task<Game> CreateGameAsync(Game game);
    public Task<IEnumerable<Game>> GetGamesByGenreAsync(string genre);
    public Task<Game> UpdateGameAsync(int id, Game game);
    public Task DeleteGameAsync(int id, Game game);
}
