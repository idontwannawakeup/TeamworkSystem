using MediatR;

namespace TeamworkSystem.WorkManagement.Application.Projects.Commands.AddProject;

public class AddProjectCommand : IRequest
{
    public Guid TeamId { get; set; }
    public string Title { get; set; } = default!;
    public string? Type { get; set; }
    public string? Url { get; set; }
    public string? Description { get; set; }
}
