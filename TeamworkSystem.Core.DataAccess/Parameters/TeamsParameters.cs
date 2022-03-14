using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Shared.Parameters;

namespace TeamworkSystem.Core.DataAccess.Parameters;

public class TeamsParameters : QueryStringParameters, IFilterParameters<Team>
{
    public Guid? UserId { get; set; }
    public string? Name { get; set; }
    public string? Specialization { get; set; }
}
