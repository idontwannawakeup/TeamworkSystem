using MediatR;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;

namespace TeamworkSystem.WorkManagement.Application.Features.Projects.Queries.GetProjectById;

public class GetProjectByIdQuery : IRequest<ProjectResponse>
{
    public Guid Id { get; set; }
}
