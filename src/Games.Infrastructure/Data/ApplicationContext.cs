using Games.Application;
using Games.Application.Interfaces;
using Games.Application.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Games.Infrastructure.Data;

public class ApplicationContext : DbContext, IApplicationContext
{
    public DbSet<Game> Games { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(Games.Application.DependencyInjection).Assembly);
    }
}
