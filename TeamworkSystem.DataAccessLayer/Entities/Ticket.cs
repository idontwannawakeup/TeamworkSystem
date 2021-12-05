using System;

namespace TeamworkSystem.DataAccessLayer.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string ExecutorId { get; set; }

        public string Title { get; set; }

        public string? Type { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? Deadline { get; set; }

        public Project Project { get; set; }

        public User Executor { get; set; }
    }
}
