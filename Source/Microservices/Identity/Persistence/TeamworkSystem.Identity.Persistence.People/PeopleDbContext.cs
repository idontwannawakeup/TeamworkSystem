using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Identity.Persistence.People.Data.Entities;

namespace TeamworkSystem.Identity.Persistence.People;

public class PeopleDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
