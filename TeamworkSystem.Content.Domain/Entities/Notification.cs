namespace TeamworkSystem.Content.Domain.Entities;

public class Notification
{
    public Guid Id { get; set; }
    public Guid NotifiedUserId { get; set; }

    public string Title { get; set; } = default!;
    public string Message { get; set; } = default!;
    public DateTime NotifiedAt { get; set; }

    public UserProfile NotifiedUser { get; set; } = default!;
}
