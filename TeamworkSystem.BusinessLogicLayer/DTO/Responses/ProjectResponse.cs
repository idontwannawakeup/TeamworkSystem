﻿namespace TeamworkSystem.BusinessLogicLayer.DTO.Responses
{
    public class ProjectResponse
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public TeamResponse Team { get; set; }
    }
}
