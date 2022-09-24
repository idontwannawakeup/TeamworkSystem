namespace TeamworkSystem.Content.Application.Common.Models.Responses;

public class NotificationResponse
{
    public Guid Id { get; set; }
    public Guid NotifiedUserId { get; set; }

    public string Title { get; set; } = default!;
    public string Message { get; set; } = default!;
    public DateTime NotifiedAt { get; set; }
}
