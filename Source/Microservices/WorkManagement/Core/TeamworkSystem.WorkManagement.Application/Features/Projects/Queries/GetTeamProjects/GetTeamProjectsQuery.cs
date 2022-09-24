using MediatR;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;

namespace TeamworkSystem.WorkManagement.Application.Features.Projects.Queries.GetTeamProjects;

public class GetTeamProjectsQuery : IRequest<IEnumerable<ProjectResponse>>
{
    public Guid TeamId { get; set; }
}
