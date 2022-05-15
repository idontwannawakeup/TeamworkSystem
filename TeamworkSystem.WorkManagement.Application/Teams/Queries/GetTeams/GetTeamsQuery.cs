using MediatR;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Application.Common.Responses;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Application.Teams.Queries.GetTeams;

public class GetTeamsQuery : IRequest<PagedList<TeamResponse>>
{
    public TeamsParameters Parameters { get; set; } = default!;
}
