using TeamworkSystem.Identity.DataAccess.Entities;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Shared.Parameters;

namespace TeamworkSystem.Identity.DataAccess.Parameters;

public class UsersParameters : QueryStringParameters, IFilterParameters<User>
{
    public Guid? TeamId { get; set; }
    public string? LastName { get; set; }
}
