using MediatR;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Application.Features.Projects.Queries.GetProjects;

public class GetProjectsQuery : IRequest<PagedList<ProjectResponse>>
{
    public ProjectsParameters Parameters { get; set; } = default!;
}
