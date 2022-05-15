using Microsoft.AspNetCore.Identity;
using TeamworkSystem.Identity.DataAccess.Entities;
using TeamworkSystem.Identity.DataAccess.Interfaces;

namespace TeamworkSystem.Identity.DataAccess.Data;

public class UnitOfWork : IUnitOfWork
{
    protected readonly IdentityExtDbContext DatabaseContext;

    public UnitOfWork(
        IdentityExtDbContext databaseContext,
        UserManager<User> userManager)
    {
        DatabaseContext = databaseContext;
        UserManager = userManager;
    }

    public UserManager<User> UserManager { get; }

    public async Task SaveChangesAsync() => await DatabaseContext.SaveChangesAsync();
}
