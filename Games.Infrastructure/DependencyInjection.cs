using Games.Application.Interfaces;
using Games.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Games.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddGamesInfrastructure(IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>(builder =>
            builder.UseInMemoryDatabase("Database"));
        services.AddScoped<IApplicationContext, ApplicationContext>();
        return services;
    }
}
