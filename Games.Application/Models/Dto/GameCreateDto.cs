namespace Games.Application.Models.Dto;

public record GameCreateDto
{
    public string Name { get; init; } = string.Empty;
    public string Developer { get; init; } = string.Empty;
    public IEnumerable<string> Genres { get; init; } = Array.Empty<string>();
}
