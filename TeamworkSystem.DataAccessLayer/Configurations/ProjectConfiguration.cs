using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.DataAccessLayer.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(project => project.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            builder.Property(project => project.Title)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(project => project.Type)
                   .HasMaxLength(50);
            
            builder.Property(project => project.Url)
                   .HasMaxLength(50);

            builder.Property(project => project.Description)
                   .HasColumnType("ntext");

            builder.HasOne(project => project.Team)
                   .WithMany(team => team.Projects)
                   .HasForeignKey(project => project.TeamId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .HasConstraintName("FK_Projects_TeamId");
        }
    }
}
