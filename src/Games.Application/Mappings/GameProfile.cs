using AutoMapper;
using Games.Application.Models.Dto;
using Games.Application.Models.Entities;

namespace Games.Application.Mappings;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<GameCreateDto, Game>()
            .ForMember(prop => prop.Id,
                opts => opts.Ignore());
    }
}
