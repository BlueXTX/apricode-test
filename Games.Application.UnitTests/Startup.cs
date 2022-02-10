using Microsoft.Extensions.DependencyInjection;

namespace Games.Application.UnitTests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddGamesApplication();
    }
}
