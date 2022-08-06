using Microsoft.AspNetCore.Identity;
using TeamworkSystem.Identity.Persistence.People.Entities;

namespace TeamworkSystem.Identity.Persistence.People.Interfaces;

public interface IUnitOfWork
{
    UserManager<User> UserManager { get; }

    Task SaveChangesAsync();
}
