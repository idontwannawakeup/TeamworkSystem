namespace TeamworkSystem.Content.Domain.Entities;

public class RecentTicket
{
    public Guid UserId { get; set; }
    public Guid TicketId { get; set; }
    public DateTime RequestedAt { get; set; }
}
