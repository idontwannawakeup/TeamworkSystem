using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Persistence.Configurations;

public class RecentTicketConfiguration : IEntityTypeConfiguration<RecentTicket>
{
    public void Configure(EntityTypeBuilder<RecentTicket> builder)
    {
        builder.HasKey(e => new { e.UserId, e.TicketId });
    }
}
