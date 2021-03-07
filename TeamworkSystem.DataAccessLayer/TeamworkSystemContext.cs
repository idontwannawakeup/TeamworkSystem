using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Configurations;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.DataAccessLayer
{
    public class TeamworkSystemContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
        }

        public TeamworkSystemContext(DbContextOptions<TeamworkSystemContext> options)
            : base(options)
        {
        }
    }
}
