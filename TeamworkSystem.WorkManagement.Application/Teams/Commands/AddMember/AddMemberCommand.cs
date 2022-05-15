using MediatR;

namespace TeamworkSystem.WorkManagement.Application.Teams.Commands.AddMember;

public class AddMemberCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid TeamId { get; set; }
}
