namespace TeamworkSystem.WebClient.ViewModels;

public class TicketViewModel
{
    public Guid Id { get; set; }

    public Guid ProjectId { get; set; }

    public Guid ExecutorId { get; set; }

    public string Title { get; set; }

    public string Type { get; set; }

    public string Description { get; set; }

    public string Status { get; set; }

    public string Priority { get; set; }

    public DateTime CreationTime { get; set; }

    public DateTime? Deadline { get; set; }

    public ProjectViewModel Project { get; set; }

    public UserViewModel Executor { get; set; }
}
