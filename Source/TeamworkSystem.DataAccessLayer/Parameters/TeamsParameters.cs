using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;

namespace TeamworkSystem.DataAccessLayer.Parameters;

public class TeamsParameters : QueryStringParameters, IFilterParameters<Team>
{
    public string? UserId { get; set; }
    public string? Name { get; set; }
    public string? Specialization { get; set; }
}
