using TeamworkSystem.DataAccessLayer.Parameters;
using TeamworkSystem.Identity.DataAccess.Entities;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Identity.DataAccess.Parameters;

public class UsersParameters : QueryStringParameters, IFilterParameters<User>
{
    public int? TeamId { get; set; }
    public string? LastName { get; set; }
}
