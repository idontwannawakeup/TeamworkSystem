using MediatR;

namespace TeamworkSystem.WorkManagement.Application.Teams.Commands.DeleteTeam;

public class DeleteTeamCommand : IRequest
{
    public Guid Id { get; set; }
}
