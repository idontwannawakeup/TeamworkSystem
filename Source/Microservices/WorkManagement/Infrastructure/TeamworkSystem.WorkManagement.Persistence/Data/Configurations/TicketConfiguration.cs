using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.WorkManagement.Domain.Entities;
using TeamworkSystem.WorkManagement.Persistence.Data.Seeders;

namespace TeamworkSystem.WorkManagement.Persistence.Data.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.Property(ticket => ticket.Id)
               .ValueGeneratedOnAdd()
               .IsRequired();

        builder.Property(ticket => ticket.ProjectId)
               .IsRequired();

        builder.Property(ticket => ticket.Title)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(ticket => ticket.Type)
               .HasMaxLength(50);

        builder.Property(ticket => ticket.Description)
               .HasColumnType("ntext")
               .IsRequired();

        builder.Property(ticket => ticket.Status)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(ticket => ticket.Priority)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(ticket => ticket.CreationTime)
               .HasColumnType("datetime")
               .HasDefaultValueSql("GETDATE()")
               .IsRequired();

        builder.Property(ticket => ticket.Deadline)
               .HasColumnType("datetime");

        builder.HasOne(ticket => ticket.Project)
               .WithMany(project => project.Tickets)
               .HasForeignKey(ticket => ticket.ProjectId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Tickets_ProjectId");

        builder.HasOne(ticket => ticket.Executor)
               .WithMany(user => user.Tickets)
               .HasForeignKey(ticket => ticket.ExecutorId)
               .OnDelete(DeleteBehavior.SetNull)
               .HasConstraintName("FK_Tickets_ExecutorId");

        new TicketSeeder().Seed(builder);
    }
}
