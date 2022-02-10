﻿using System.Threading;
using System.Threading.Tasks;
using Games.Application.Interfaces;
using Games.Application.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Games.Application.UnitTests;

public class TestApplicationContext : DbContext, IApplicationContext
{
    public DbSet<Game> Games { get; set; }

    public TestApplicationContext(DbContextOptions<TestApplicationContext> options) : base(options)
    {
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await base.SaveChangesAsync(cancellationToken);
    }
}
