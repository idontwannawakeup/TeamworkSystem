using MediatR;
using TeamworkSystem.WorkManagement.Application.Common.Responses;

namespace TeamworkSystem.WorkManagement.Application.Teams.Queries.GetTeamMembers;

public class GetTeamMembersQuery : IRequest<IEnumerable<UserResponse>>
{
    public Guid TeamId { get; set; } = default!;
}
