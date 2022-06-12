using MediatR;
using TeamworkSystem.WorkManagement.Application.Common.Responses;

namespace TeamworkSystem.WorkManagement.Application.Projects.Queries.GetTeamProjects;

public class GetTeamProjectsQuery : IRequest<IEnumerable<ProjectResponse>>
{
    public Guid TeamId { get; set; }
}
