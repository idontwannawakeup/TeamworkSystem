using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Core.DataAccess.Entities;

namespace TeamworkSystem.Core.DataAccess;

public class TeamworkSystemCoreDbContext : DbContext
{
    public TeamworkSystemCoreDbContext(DbContextOptions<TeamworkSystemCoreDbContext> options) : base(options)
    {
    }

    public DbSet<Team> Teams { get; set; } = default!;
    public DbSet<Project> Projects { get; set; } = default!;
    public DbSet<Ticket> Tickets { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
