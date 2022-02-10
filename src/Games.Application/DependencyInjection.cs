using Games.Application.Interfaces;
using Games.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Games.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddGamesApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<IGamesService, GamesService>();
        return services;
    }
}
