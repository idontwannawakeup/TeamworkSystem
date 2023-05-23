using MediatR;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;

namespace TeamworkSystem.WorkManagement.Application.Features.Teams.Queries.GetUserTeams;

public class GetUserTeamsQuery : IRequest<IEnumerable<TeamResponse>>
{
    public Guid UserId { get; set; }
}
