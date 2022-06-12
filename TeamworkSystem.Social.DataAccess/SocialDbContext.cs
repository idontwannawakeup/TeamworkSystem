using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Social.DataAccess.Entities;

namespace TeamworkSystem.Social.DataAccess;

public class SocialDbContext : DbContext
{
    public SocialDbContext(DbContextOptions<SocialDbContext> options) : base(options)
    {
    }

    public DbSet<Rating> Ratings { get; set; } = default!;
    public DbSet<Rating> UserProfiles { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
