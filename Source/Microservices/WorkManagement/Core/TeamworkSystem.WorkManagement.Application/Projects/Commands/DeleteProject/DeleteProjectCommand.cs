using MediatR;

namespace TeamworkSystem.WorkManagement.Application.Projects.Commands.DeleteProject;

public class DeleteProjectCommand : IRequest
{
    public Guid Id { get; set; }
}
