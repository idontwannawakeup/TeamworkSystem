namespace TeamworkSystem.EventBus.Messages;

public class UserAvatarChangedEvent
{
    public Guid UserId { get; set; }
    public string Avatar { get; set; } = default!;
}
