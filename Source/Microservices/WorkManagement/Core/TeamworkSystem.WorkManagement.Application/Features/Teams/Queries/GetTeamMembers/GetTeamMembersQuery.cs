using MediatR;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;

namespace TeamworkSystem.WorkManagement.Application.Features.Teams.Queries.GetTeamMembers;

public class GetTeamMembersQuery : IRequest<IEnumerable<UserResponse>>
{
    public Guid TeamId { get; set; } = default!;
}
