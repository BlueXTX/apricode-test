using Games.Application.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Games.Application.Interfaces;

public interface IApplicationContext
{
    public DbSet<Game> Games { get; set; }

    public Task SaveChangesAsync(CancellationToken cancellationToken);
}
