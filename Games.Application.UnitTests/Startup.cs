using System;
using Games.Application.Interfaces;
using Games.Application.UnitTests.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Games.Application.UnitTests;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddGamesApplication();
        services.AddDbContext<TestApplicationContext>(builder =>
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString()),
            ServiceLifetime.Transient);
        services.AddTransient<IApplicationContext, TestApplicationContext>();
    }
}
