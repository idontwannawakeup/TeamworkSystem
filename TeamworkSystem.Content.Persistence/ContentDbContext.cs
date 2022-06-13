using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Persistence;

public class ContentDbContext : DbContext
{
    public ContentDbContext(DbContextOptions<ContentDbContext> options) : base(options)
    {
    }

    public DbSet<Notification> Notifications { get; set; } = default!;
    public DbSet<NotificationTemplate> NotificationTemplates { get; set; } = default!;
    public DbSet<RecentProject> RecentProjects { get; set; } = default!;
    public DbSet<RecentTeam> RecentTeams { get; set; } = default!;
    public DbSet<RecentTicket> RecentTickets { get; set; } = default!;
    public DbSet<UserProfile> UserProfiles { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
