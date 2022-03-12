using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Interfaces.Seeders;

namespace TeamworkSystem.Core.DataAccess.Seeders;

public class TicketSeeder : ITicketSeeder
{
    private static readonly List<Ticket> Tickets = new()
    {
        new Ticket
        {
            Id = 1,
            ProjectId = 1,
            ExecutorId = "61dfb9e3-1c27-424a-9963-9586ca110220",
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
