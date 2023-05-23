namespace TeamworkSystem.Content.Application.Common.Models.Responses;

public class TicketResponse
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid? ExecutorId { get; set; }

    public string Title { get; set; } = default!;
    public string? Type { get; set; }
    public string Description { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string Priority { get; set; } = default!;
    public DateTime CreationTime { get; set; }
    public DateTime? Deadline { get; set; }

    public ProjectResponse Project { get; set; } = default!;
    public UserResponse Executor { get; set; } = default!;
}
