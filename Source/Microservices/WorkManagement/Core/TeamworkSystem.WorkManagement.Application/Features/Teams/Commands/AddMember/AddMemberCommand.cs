using MediatR;

namespace TeamworkSystem.WorkManagement.Application.Features.Teams.Commands.AddMember;

public class AddMemberCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid TeamId { get; set; }
}
