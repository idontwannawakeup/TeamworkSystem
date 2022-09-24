using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.DataAccessLayer;

public class TeamworkSystemContext : IdentityDbContext<User>
{
    public TeamworkSystemContext(DbContextOptions<TeamworkSystemContext> options) : base(options)
    {
    }

    public DbSet<Team> Teams { get; set; } = default!;
    public DbSet<Project> Projects { get; set; } = default!;
    public DbSet<Ticket> Tickets { get; set; } = default!;
    public DbSet<Rating> Ratings { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
