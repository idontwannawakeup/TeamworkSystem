using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.WorkManagement.Application.Interfaces.Seeders;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Persistence.Seeders;

public class TicketSeeder : ITicketSeeder
{
    private static readonly List<Ticket> Tickets = new()
    {
        new Ticket
        {
            Id = new Guid("61c21020-30a0-47a6-8b9d-607b6b9f68b0"),
            ProjectId = Guid.Parse("2f73e5de-7fb3-47c1-9756-ea8a499d8eac"),
            ExecutorId = Guid.Parse("61dfb9e3-1c27-424a-9963-9586ca110220"),
            Title = "Fix bug",
            Description = "There's unknown bug. Just fix it.",
            Type = "Epic",
            Status = "Backlog",
            Priority = "Medium",
            CreationTime = DateTime.Parse("1/6/2022 1:57:03 PM")
        }
    };

    public void Seed(EntityTypeBuilder<Ticket> builder) => builder.HasData(Tickets);
}
