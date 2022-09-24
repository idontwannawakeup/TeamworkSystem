using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;

namespace TeamworkSystem.DataAccessLayer.Parameters;

public class ProjectsParameters : QueryStringParameters, IFilterParameters<Project>
{
    public int? TeamId { get; set; }
    public string? TeamMemberId { get; set; }
    public string? Title { get; set; }
}
