using Microsoft.AspNetCore.Identity;
using TeamworkSystem.Identity.Persistence.People.Data.Entities;

namespace TeamworkSystem.Identity.Persistence.People.Interfaces.Data;

public interface IUnitOfWork
{
    UserManager<User> UserManager { get; }

    Task SaveChangesAsync();
}
