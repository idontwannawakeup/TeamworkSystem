using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Seeding
{
    public class TicketSeeder : ISeeder<Ticket>
    {
        private static readonly List<Ticket> tickets = new()
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
                CreationTime = DateTime.Now
            }
        };

        public void Seed(EntityTypeBuilder<Ticket> builder) => builder.HasData(tickets);
    }
}
