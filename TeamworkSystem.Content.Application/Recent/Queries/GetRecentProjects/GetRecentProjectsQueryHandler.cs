using MediatR;
using TeamworkSystem.Content.Application.Common.Responses;

namespace TeamworkSystem.Content.Application.Recent.Queries.GetRecentProjects;

public class GetRecentProjectsQueryHandler
    : IRequestHandler<GetRecentProjectsQuery, IEnumerable<ProjectResponse>>
{
    public Task<IEnumerable<ProjectResponse>> Handle(
        GetRecentProjectsQuery request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(Array.Empty<ProjectResponse>() as IEnumerable<ProjectResponse>);
    }
}
