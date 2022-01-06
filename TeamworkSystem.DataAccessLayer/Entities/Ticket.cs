namespace TeamworkSystem.DataAccessLayer.Entities;

public class Ticket
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string? ExecutorId { get; set; }

    public string Title { get; set; } = default!;
    public string? Type { get; set; }
    public string Description { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string Priority { get; set; } = default!;
    public DateTime CreationTime { get; set; }
    public DateTime? Deadline { get; set; }

    public Project Project { get; set; } = default!;
    public User? Executor { get; set; }
}
