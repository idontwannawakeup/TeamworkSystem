using MediatR;
using TeamworkSystem.WorkManagement.Application.Common.Responses;

namespace TeamworkSystem.WorkManagement.Application.Teams.Queries.GetUserTeams;

public class GetUserTeamsQuery : IRequest<IEnumerable<TeamResponse>>
{
    public Guid UserId { get; set; }
}
