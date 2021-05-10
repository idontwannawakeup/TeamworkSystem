using System;

namespace TeamworkSystem.WebClient.ViewModels
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? Deadline { get; set; }

        public UserViewModel Executor { get; set; }
    }
}
