using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Seeding;

namespace TeamworkSystem.DataAccessLayer.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
       public void Configure(EntityTypeBuilder<Team> builder)
       {
              builder.Property(team => team.Id)
                     .UseIdentityColumn()
                     .IsRequired();

              builder.Property(team => team.Name)
                     .HasMaxLength(50)
                     .IsRequired();

              builder.Property(team => team.Specialization)
                     .HasMaxLength(50);

              builder.Property(team => team.About)
                     .HasColumnType("ntext");

              builder.HasOne(team => team.Leader)
                     .WithMany()
                     .HasForeignKey(team => team.LeaderId)
                     .OnDelete(DeleteBehavior.SetNull)
                     .HasConstraintName("FK_Teams_LeaderId");

              builder.HasMany(team => team.Members)
                     .WithMany(user => user.Teams)
                     .UsingEntity(entity =>
                     {
                            entity.ToTable("TeamsMembers");
                            entity.Property("MembersId").HasColumnName("UserId");
                            entity.Property("TeamsId").HasColumnName("TeamId");
                     });

              new TeamSeeder().Seed(builder);
       }
}
