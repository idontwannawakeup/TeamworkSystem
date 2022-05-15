using Microsoft.EntityFrameworkCore;
using TeamworkSystem.WorkManagement.DataAccess.Entities;

namespace TeamworkSystem.WorkManagement.DataAccess;

public class WorkManagementDbContext : DbContext
{
    public WorkManagementDbContext(DbContextOptions<WorkManagementDbContext> options) : base(options)
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
