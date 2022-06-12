namespace TeamworkSystem.WorkManagement.Domain.Entities;

public class Project
{
    public Guid Id { get; set; }
    public Guid TeamId { get; set; }

    public string Title { get; set; } = default!;
    public string? Type { get; set; }
    public string? Url { get; set; }
    public string? Description { get; set; }

    public Team Team { get; set; } = default!;
    public List<Ticket> Tickets { get; set; } = default!;
}
