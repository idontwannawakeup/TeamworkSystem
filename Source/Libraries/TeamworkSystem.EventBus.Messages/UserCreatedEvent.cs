namespace TeamworkSystem.EventBus.Messages;

public class UserCreatedEvent : IntegrationBaseEvent
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Profession { get; set; }
    public string? Specialization { get; set; }
}
