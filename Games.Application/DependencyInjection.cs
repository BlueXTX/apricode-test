using Microsoft.Extensions.DependencyInjection;

namespace Games.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddGamesApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}
