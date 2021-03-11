using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Models
{
    public class Team : IIdentifiableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? LeaderId { get; set; }

        public string? Specialization { get; set; }

        public string? About { get; set; }

        public Team(int id,
            string name,
            int? leaderId,
            string? specialization,
            string? about)
        {
            this.Id = id;
            this.Name = name;
            this.LeaderId = leaderId;
            this.Specialization = specialization;
            this.About = about;
        }
    }
}
