using MediatR;

namespace TeamworkSystem.WorkManagement.Application.Features.Teams.Commands.DeleteMember;

public class DeleteMemberCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid TeamId { get; set; }
}
