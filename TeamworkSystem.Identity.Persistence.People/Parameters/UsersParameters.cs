using TeamworkSystem.Identity.Persistence.People.Entities;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Shared.Parameters;

namespace TeamworkSystem.Identity.Persistence.People.Parameters;

public class UsersParameters : QueryStringParameters, IFilterParameters<User>
{
    // TODO: think about what to do with TeamId, current solution - get members with teams controller
    // public Guid? TeamId { get; set; }
    public string? LastName { get; set; }
}
