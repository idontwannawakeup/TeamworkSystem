using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.Social.DataAccess.Entities;
using TeamworkSystem.Social.DataAccess.Seeders;

namespace TeamworkSystem.Social.DataAccess.Configurations;

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

        builder.HasMany(user => user.Friends)
               .WithMany(user => user.FriendForUsers)
               .UsingEntity(entity =>
               {
                   entity.ToTable("Friends");
                   entity.Property("FriendsId").HasColumnName("FirstId");
                   entity.Property("FriendForUsersId").HasColumnName("SecondId");
               });

        new UserProfileSeeder().Seed(builder);
    }
}
