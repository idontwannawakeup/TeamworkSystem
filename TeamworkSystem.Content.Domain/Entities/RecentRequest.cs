using TeamworkSystem.Content.Domain.Enums;

namespace TeamworkSystem.Content.Domain.Entities;

public class RecentRequest
{
    public Guid UserId { get; set; }
    public Guid RequestedEntityId { get; set; }
    public RecentRequestEntityType RecentRequestEntityType { get; set; }
    public DateTime RequestedAt { get; set; }
}
