using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;

namespace TeamworkSystem.DataAccessLayer.Parameters;

public class UsersParameters : QueryStringParameters, IFilterParameters<User>
{
    public int? TeamId { get; set; }
    public string? LastName { get; set; }
}
