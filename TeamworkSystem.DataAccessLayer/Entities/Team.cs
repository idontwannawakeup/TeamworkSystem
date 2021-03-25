using System.Collections.Generic;

namespace TeamworkSystem.DataAccessLayer.Entities
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LeaderId { get; set; }

        public string Specialization { get; set; }

        public string About { get; set; }

        public User Leader { get; set; }

        public List<Project> Projects { get; set; }

        public List<User> Members { get; set; }
    }
}
