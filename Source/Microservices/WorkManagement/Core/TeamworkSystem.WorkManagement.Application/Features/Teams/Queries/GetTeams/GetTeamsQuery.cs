using MediatR;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Application.Features.Teams.Queries.GetTeams;

public class GetTeamsQuery : IRequest<PagedList<TeamResponse>>
{
    public TeamsParameters Parameters { get; set; } = default!;
}
