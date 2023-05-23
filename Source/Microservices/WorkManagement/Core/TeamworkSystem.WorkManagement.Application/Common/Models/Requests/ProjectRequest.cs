namespace TeamworkSystem.WorkManagement.Application.Common.Models.Requests;

public class ProjectRequest
{
    public Guid Id { get; set; }
    public Guid TeamId { get; set; }

    public string Title { get; set; } = default!;
    public string? Type { get; set; }
    public string? Url { get; set; }

    public string? Description { get; set; }
}
