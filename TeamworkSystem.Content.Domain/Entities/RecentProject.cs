namespace TeamworkSystem.Content.Domain.Entities;

public class RecentProject
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public DateTime RequestedAt { get; set; }
}
