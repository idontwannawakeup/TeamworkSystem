namespace TeamworkSystem.EventBus.Messages.RecentEvents;

public class TeamAddedToRecentEvent
{
    public Guid UserId { get; set; }
    public Guid TeamId { get; set; }
}
