using TeamworkSystem.Identity.Persistence.People.Interfaces.Data;
using TeamworkSystem.Identity.Persistence.People.Interfaces.Data.Repositories;

namespace TeamworkSystem.Identity.Persistence.People.Data;

public class UnitOfWork : IUnitOfWork
{
    protected readonly PeopleDbContext DatabaseContext;

    public UnitOfWork(
        PeopleDbContext databaseContext,
        IUsersRepository usersRepository)
    {
        DatabaseContext = databaseContext;
        UsersRepository = usersRepository;
    }

    public IUsersRepository UsersRepository { get; set; }

    public async Task SaveChangesAsync() => await DatabaseContext.SaveChangesAsync();
}
