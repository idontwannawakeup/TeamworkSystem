using MediatR;
using TeamworkSystem.Content.Application.Common.Models.Responses;

namespace TeamworkSystem.Content.Application.Features.Recent.Queries.GetRecentProjects;

public class GetRecentProjectsQuery : IRequest<IEnumerable<ProjectResponse>>
{
    public Guid UserId { get; set; }
}
