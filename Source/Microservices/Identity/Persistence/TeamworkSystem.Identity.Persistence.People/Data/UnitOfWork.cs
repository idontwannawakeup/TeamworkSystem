using Microsoft.AspNetCore.Identity;
using TeamworkSystem.Identity.Persistence.People.Data.Entities;
using TeamworkSystem.Identity.Persistence.People.Interfaces.Data;

namespace TeamworkSystem.Identity.Persistence.People.Data;

public class UnitOfWork : IUnitOfWork
{
    protected readonly PeopleDbContext DatabaseContext;

    public UnitOfWork(
        PeopleDbContext databaseContext,
        UserManager<User> userManager)
    {
        DatabaseContext = databaseContext;
        UserManager = userManager;
    }

    public UserManager<User> UserManager { get; }

    public async Task SaveChangesAsync() => await DatabaseContext.SaveChangesAsync();
}
