using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Social.DataAccess.Entities;

namespace TeamworkSystem.Social.DataAccess;

public class TeamworkSystemSocialDbContext : DbContext
{
    public TeamworkSystemSocialDbContext(DbContextOptions<TeamworkSystemSocialDbContext> options) : base(options)
    {
    }

    public DbSet<Rating> Ratings { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
