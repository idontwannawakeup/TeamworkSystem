using MediatR;
using TeamworkSystem.Content.Application.Common.Responses;

namespace TeamworkSystem.Content.Application.Recent.Queries.GetRecentTeams;

public class GetRecentTeamsQueryHandler
    : IRequestHandler<GetRecentTeamsQuery, IEnumerable<TeamResponse>>
{
    public Task<IEnumerable<TeamResponse>> Handle(
        GetRecentTeamsQuery request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(Array.Empty<TeamResponse>() as IEnumerable<TeamResponse>);
    }
}
