using MediatR;
using TeamworkSystem.Content.Application.Common.Responses;

namespace TeamworkSystem.Content.Application.Features.Recent.Queries.GetRecentTeams;

public class GetRecentTeamsQuery : IRequest<IEnumerable<TeamResponse>>
{
    public Guid UserId { get; set; }
}
