﻿namespace TeamworkSystem.WebClient.Parameters
{
    public class TicketsParameters : QueryStringParameters
    {
        public int? ProjectId { get; set; }

        public string ExecutorId { get; set; }
    }
}
