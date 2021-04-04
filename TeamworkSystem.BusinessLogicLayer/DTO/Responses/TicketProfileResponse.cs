using System;

namespace TeamworkSystem.BusinessLogicLayer.DTO.Responses
{
    public class TicketProfileResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public DateTime Deadline { get; set; }
    }
}
