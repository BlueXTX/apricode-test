using FluentValidation;
using Games.Application.Models.Dto;

namespace Games.Application.Validators;

public class GameCreateDtoValidator : AbstractValidator<GameCreateDto>
{
    public GameCreateDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Developer).NotEmpty();
        RuleFor(x => x.Genres).NotEmpty();
    }
}
