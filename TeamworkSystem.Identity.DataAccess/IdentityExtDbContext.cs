using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.Identity.DataAccess.Entities;

namespace TeamworkSystem.Identity.DataAccess;

public class IdentityExtDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public IdentityExtDbContext(DbContextOptions<IdentityExtDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
