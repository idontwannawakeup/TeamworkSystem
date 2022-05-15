using MediatR;
using TeamworkSystem.WorkManagement.Application.Common.Responses;

namespace TeamworkSystem.WorkManagement.Application.Projects.Queries.GetProjectById;

public class GetProjectByIdQuery : IRequest<ProjectResponse>
{
    public Guid Id { get; set; }
}
