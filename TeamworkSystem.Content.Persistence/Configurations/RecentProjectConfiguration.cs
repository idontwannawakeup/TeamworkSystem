using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Persistence.Configurations;

public class RecentProjectConfiguration : IEntityTypeConfiguration<RecentProject>
{
    public void Configure(EntityTypeBuilder<RecentProject> builder)
    {
        builder.HasKey(e => new { e.UserId, e.ProjectId });
    }
}
