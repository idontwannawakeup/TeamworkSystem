using System;
using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Models
{
    public class Ticket : IIdentifiableEntity
    {
        public int Id { get; set; }
        
        public int ProjectId { get; set; }
        
        public int? ExecutorId { get; set; }
        
        public string Title { get; set; }
        
        public string? Type { get; set; }
        
        public string Description { get; set; }
        
        public string Status { get; set; }
        
        public string Priority { get; set; }
        
        public DateTime CreationTime { get; set; }
        
        public DateTime? Deadline { get; set; }

        public Ticket(int id,
            int projectId,
            int? executorId,
            string title,
            string? type,
            string description,
            string status,
            string priority,
            DateTime creationTime,
            DateTime? deadline)
        {
            this.Id = id;
            this.ProjectId = projectId;
            this.ExecutorId = executorId;
            this.Title = title;
            this.Type = type;
            this.Description = description;
            this.Status = status;
            this.Priority = priority;
            this.CreationTime = creationTime;
            this.Deadline = deadline;
        }
    }
}