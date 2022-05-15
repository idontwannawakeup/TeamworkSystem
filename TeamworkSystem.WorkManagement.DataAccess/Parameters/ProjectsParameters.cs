using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Shared.Parameters;
using TeamworkSystem.WorkManagement.DataAccess.Entities;

namespace TeamworkSystem.WorkManagement.DataAccess.Parameters;

public class ProjectsParameters : QueryStringParameters, IFilterParameters<Project>
{
    public Guid? TeamId { get; set; }
    public Guid? TeamMemberId { get; set; }
    public string? Title { get; set; }
}
