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
                CreationTime = DateTime.Now,
            },
            new Ticket
            {
                Id = 2,
                ProjectId = 2,
                ExecutorId = "013a2014-4a25-4a3d-9fae-e0f783d42ef9",
                Title = "Fix a regular bug",
                Description = "There's a known bug. Just fix it.",
                Type = "Epic",
                Status = "Backlog",
                Priority = "Medium",
                CreationTime = DateTime.Now,
            },
            new Ticket
            {
                Id = 3,
                ProjectId = 1,
                ExecutorId = "61dfb9e3-1c27-424a-9963-9586ca110220",
                Title = "Fix something there",
                Description = "There's a mess of bugs, you have to figure out how to fix them. Good Luck.",
                Type = "Bug",
                Status = "Chosen For Development",
                Priority = "High",
                CreationTime = DateTime.Now,
            },
            new Ticket
            {
                Id = 4,
                ProjectId = 1,
                ExecutorId = "61dfb9e3-1c27-424a-9963-9586ca110220",
                Title = "Updating Software Versions",
                Description = "This task involves identifying outdated software versions and updating them to the latest version to ensure optimal performance and security.",
                Type = "Task",
                Status = "In Progress",
                Priority = "Low",
                CreationTime = DateTime.Now,
            },
            new Ticket
            {
                Id = 5,
                ProjectId = 1,
                ExecutorId = "61dfb9e3-1c27-424a-9963-9586ca110220",
                Title = "Troubleshooting Network Connectivity Issues",
                Description = "In this task, you will diagnose and resolve network connectivity issues, including identifying faulty hardware, configuring network settings, and resolving software conflicts.",
                Type = "Task",
                Status = "Chosen For Development",
                Priority = "High",
                CreationTime = DateTime.Now,
            },
            // 3.	Title: “Setting up Email Accounts”
            // Description: This task involves creating and configuring email accounts for new users, including setting up email clients, configuring spam filters, and ensuring proper security measures are in place.
            // 4.	Title: “Data Backup and Recovery”
            // Description: This task involves implementing and maintaining a data backup and recovery plan, including regularly backing up critical data, testing backup systems, and restoring data in the event of data loss.
            // 5.	Title: “Installing and Configuring Software”
            // Description: In this task, you will install and configure software applications according to user requirements, including configuring settings, creating user accounts, and ensuring compatibility with existing systems.
        };

        public void Seed(EntityTypeBuilder<Ticket> builder) => builder.HasData(tickets);
    }
}
