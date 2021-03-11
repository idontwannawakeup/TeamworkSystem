using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Models
{
    public class Project : IIdentifiableEntity
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public string Title { get; set; }

        public string? Type { get; set; }

        public string? Url { get; set; }

        public string? Description { get; set; }

        public Project(int id,
            int teamId,
            string title,
            string? type,
            string? url,
            string? description)
        {
            this.Id = id;
            this.TeamId = teamId;
            this.Title = title;
            this.Type = type;
            this.Url = url;
            this.Description = description;
        }
    }
}
