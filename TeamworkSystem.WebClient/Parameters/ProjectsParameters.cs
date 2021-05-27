﻿namespace TeamworkSystem.WebClient.Parameters
{
    public class ProjectsParameters : QueryStringParameters
    {
        public int? TeamId { get; set; }

        public string TeamMemberId { get; set; }

        public string Title { get; set; }
    }
}
