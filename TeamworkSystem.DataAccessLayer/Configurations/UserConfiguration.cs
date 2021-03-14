using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.DataAccessLayer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(user => user.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(user => user.Surname)
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
        }
    }
}
