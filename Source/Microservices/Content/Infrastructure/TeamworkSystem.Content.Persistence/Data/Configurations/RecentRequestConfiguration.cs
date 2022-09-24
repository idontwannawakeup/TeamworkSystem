using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Persistence.Data.Configurations;

public class RecentRequestConfiguration : IEntityTypeConfiguration<RecentRequest>
{
    public void Configure(EntityTypeBuilder<RecentRequest> builder)
    {
        builder.HasKey(e => new { UserId = e.UserProfileId, e.RequestedEntityId, e.RecentRequestEntityType });
    }
}
