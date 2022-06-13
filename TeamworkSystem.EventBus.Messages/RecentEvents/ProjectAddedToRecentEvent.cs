namespace TeamworkSystem.EventBus.Messages.RecentEvents;

public class ProjectAddedToRecentEvent
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
}
