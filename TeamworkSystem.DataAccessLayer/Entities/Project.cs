﻿using System.Collections.Generic;

namespace TeamworkSystem.DataAccessLayer.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public Team Team { get; set; }
        
        public List<Ticket> Tickets { get; set; }
    }
}
