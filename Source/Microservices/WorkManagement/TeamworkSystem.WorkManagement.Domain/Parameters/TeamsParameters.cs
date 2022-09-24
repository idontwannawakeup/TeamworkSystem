using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Shared.Parameters;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Domain.Parameters;

public class TeamsParameters : QueryStringParameters, IFilterParameters<Team>
{
    public Guid? UserId { get; set; }
    public string? Name { get; set; }
    public string? Specialization { get; set; }
}
