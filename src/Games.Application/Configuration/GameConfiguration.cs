using System.Text.Json;
using Games.Application.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Games.Application.Configuration;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder
            .Property(prop => prop.Genres)
            .HasConversion(
                v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                v =>
                    JsonSerializer.Deserialize<IEnumerable<string>>(v,
                        new JsonSerializerOptions()) ?? Array.Empty<string>());
    }
}
