namespace TeamworkSystem.Core.DataAccess.Entities;

public class Ticket
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

    public Project Project { get; set; } = default!;
    public UserProfile? Executor { get; set; }
}
