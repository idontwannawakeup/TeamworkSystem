using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Persistence.Configurations;

public class RecentRequestConfiguration : IEntityTypeConfiguration<RecentRequest>
{
    public void Configure(EntityTypeBuilder<RecentRequest> builder)
    {
        builder.HasKey(e => new { e.UserId, e.RequestedEntityId, e.RecentRequestEntityType });
    }
}
