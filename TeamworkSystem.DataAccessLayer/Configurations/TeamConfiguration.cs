using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Seeding;

namespace TeamworkSystem.DataAccessLayer.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(team => team.Id).UseIdentityColumn().IsRequired();

            builder.Property(team => team.Name).HasMaxLength(50).IsRequired();

            builder.Property(team => team.Specialization).HasMaxLength(50);

            builder.Property(team => team.About).HasColumnType("ntext");

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
                    entity.HasData(
                        new { MembersId = "61dfb9e3-1c27-424a-9963-9586ca110220", TeamsId = 9 },
                        new { MembersId = "013a2014-4a25-4a3d-9fae-e0f783d42ef9", TeamsId = 1 },
                        new { MembersId = "0a906f06-fc52-417b-bc81-352df8bbe721", TeamsId = 2 },
                        new { MembersId = "61dfb9e3-1c27-424a-9963-9586ca110220", TeamsId = 3 },
                        new { MembersId = "0a906f06-fc52-417b-bc81-352df8bbe721", TeamsId = 4 },
                        new { MembersId = "3f036c83-88e8-4aeb-ad33-290d60cf6b66", TeamsId = 5 },
                        new { MembersId = "7ad5c481-f391-45bb-a79c-cfcb1adb448b", TeamsId = 6 },
                        new { MembersId = "3b333929-f974-444e-a8d3-68f50a0459c0", TeamsId = 7 },
                        new { MembersId = "3b333929-f974-444e-a8d3-68f50a0459c0", TeamsId = 8 });
                });

            new TeamSeeder().Seed(builder);
        }
    }
}
