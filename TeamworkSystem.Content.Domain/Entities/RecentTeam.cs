namespace TeamworkSystem.Content.Domain.Entities;

public class RecentTeam
{
    public Guid UserId { get; set; }
    public Guid TeamId { get; set; }
    public DateTime RequestedAt { get; set; }
}
