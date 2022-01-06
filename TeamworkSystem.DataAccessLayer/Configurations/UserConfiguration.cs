using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Seeders;

namespace TeamworkSystem.DataAccessLayer.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
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

        new UserSeeder().Seed(builder);
    }
}
