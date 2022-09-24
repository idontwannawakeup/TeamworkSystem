using MediatR;

namespace TeamworkSystem.WorkManagement.Application.Projects.Commands.CreateProject;

public class CreateProjectCommand : IRequest
{
    public Guid TeamId { get; set; }
    public string Title { get; set; } = default!;
    public string? Type { get; set; }
    public string? Url { get; set; }
    public string? Description { get; set; }
}
