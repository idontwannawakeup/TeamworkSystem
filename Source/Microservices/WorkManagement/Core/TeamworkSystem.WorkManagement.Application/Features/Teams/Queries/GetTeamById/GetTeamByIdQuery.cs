using MediatR;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;

namespace TeamworkSystem.WorkManagement.Application.Features.Teams.Queries.GetTeamById;

public class GetTeamByIdQuery : IRequest<TeamResponse>
{
    public Guid Id { get; set; }
}
