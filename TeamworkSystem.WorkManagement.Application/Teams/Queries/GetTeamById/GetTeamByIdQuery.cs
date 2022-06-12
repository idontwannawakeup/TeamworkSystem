using MediatR;
using TeamworkSystem.WorkManagement.Application.Common.Responses;

namespace TeamworkSystem.WorkManagement.Application.Teams.Queries.GetTeamById;

public class GetTeamByIdQuery : IRequest<TeamResponse>
{
    public Guid Id { get; set; }
}
