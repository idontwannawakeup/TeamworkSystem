using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.Content.Domain.Entities;

namespace TeamworkSystem.Content.Persistence.Configurations;

public class RecentTeamConfiguration : IEntityTypeConfiguration<RecentTeam>
{
    public void Configure(EntityTypeBuilder<RecentTeam> builder)
    {
        builder.HasKey(e => new { e.UserId, e.TeamId });
    }
}
