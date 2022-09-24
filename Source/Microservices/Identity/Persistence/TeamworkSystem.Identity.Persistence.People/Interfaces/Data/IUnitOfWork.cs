using TeamworkSystem.Identity.Persistence.People.Interfaces.Data.Repositories;

namespace TeamworkSystem.Identity.Persistence.People.Interfaces.Data;

public interface IUnitOfWork
{
    IUsersRepository UsersRepository { get; set; }

    Task SaveChangesAsync();
}
