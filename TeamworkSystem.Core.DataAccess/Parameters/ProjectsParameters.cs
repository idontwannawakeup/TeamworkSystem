using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Shared.Parameters;

namespace TeamworkSystem.Core.DataAccess.Parameters;

public class ProjectsParameters : QueryStringParameters, IFilterParameters<Project>
{
    public int? TeamId { get; set; }
    public string? TeamMemberId { get; set; }
    public string? Title { get; set; }
}
