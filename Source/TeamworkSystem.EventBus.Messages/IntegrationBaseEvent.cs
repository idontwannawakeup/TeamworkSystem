namespace TeamworkSystem.EventBus.Messages;

public class IntegrationBaseEvent
{
    public Guid Id { get; set; }
    public DateTime TriggeredAt { get; } = DateTime.UtcNow;
}
