using MediatR;

namespace TeamworkSystem.WorkManagement.Application.Teams.Commands.DeleteMember;

public class DeleteMemberCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid TeamId { get; set; }
}
