namespace TeamworkSystem.EventBus.Messages.RecentEvents;

public class TicketAddedToRecentEvent
{
    public Guid UserId { get; set; }
    public Guid TicketId { get; set; }
}
