using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Seeders;

namespace TeamworkSystem.Core.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.FirstName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(user => user.LastName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(user => user.Profession)
               .HasMaxLength(50);

        builder.Property(user => user.Specialization)
               .HasMaxLength(50);

        new UserProfileSeeder().Seed(builder);
    }
}
