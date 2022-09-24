using MediatR;

namespace TeamworkSystem.WorkManagement.Application.Features.Projects.Commands.UpdateProject;

public class UpdateProjectCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid TeamId { get; set; }
    public string Title { get; set; } = default!;
    public string? Type { get; set; }
    public string? Url { get; set; }
    public string? Description { get; set; }
}
