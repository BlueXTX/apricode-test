namespace Games.Application.Models.Entities;

public record Game
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Developer { get; set; } = string.Empty;
    public IEnumerable<string> Genres { get; set; } = Array.Empty<string>();
}
