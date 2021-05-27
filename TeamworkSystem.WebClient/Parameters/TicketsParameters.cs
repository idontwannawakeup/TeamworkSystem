﻿namespace TeamworkSystem.WebClient.Parameters
{
    public class TicketsParameters : QueryStringParameters
    {
        public int? ProjectId { get; set; }

        public string ExecutorId { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }
    }
}
