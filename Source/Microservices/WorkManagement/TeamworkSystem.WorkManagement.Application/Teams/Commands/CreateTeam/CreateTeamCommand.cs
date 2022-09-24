using MediatR;

namespace TeamworkSystem.WorkManagement.Application.Teams.Commands.CreateTeam;

public class CreateTeamCommand : IRequest
{
    public Guid LeaderId { get; set; }
    public string Name { get; set; } = default!;
    public string? Specialization { get; set; }
    public string? About { get; set; }
}
