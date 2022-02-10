using AutoMapper;
using Games.Application.Interfaces;
using Games.Application.Models.Dto;
using Games.Application.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Games.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController : ControllerBase
{
    private readonly IGamesService _gamesService;
    private readonly IMapper _mapper;

    public GamesController(IGamesService gamesService, IMapper mapper)
    {
        _gamesService = gamesService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGame(GameCreateDto dto)
    {
        await _gamesService.CreateGameAsync(_mapper.Map<Game>(dto));
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetGameByGenre(string genre)
    {
        return Ok(await _gamesService.GetGamesByGenreAsync(genre));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateGame(int id, Game game)
    {
        var result = await _gamesService.UpdateGameAsync(id, game);
        return result != default ? Ok() : BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteGame(int id)
    {
        await _gamesService.DeleteGameAsync(id);
        return Ok();
    }
}
