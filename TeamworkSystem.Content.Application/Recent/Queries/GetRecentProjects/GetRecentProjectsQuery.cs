using MediatR;
using TeamworkSystem.Content.Application.Common.Responses;

namespace TeamworkSystem.Content.Application.Recent.Queries.GetRecentProjects;

public class GetRecentProjectsQuery : IRequest<IEnumerable<ProjectResponse>>
{
    public Guid UserId { get; set; }
}
