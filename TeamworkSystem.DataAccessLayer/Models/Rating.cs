using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Models
{
    public class Rating : IIdentifiableEntity
    {
        public int Id { get; set; }

        public int FromId { get; set; }

        public int ToId { get; set; }

        public int Social { get; set; }

        public int Skills { get; set; }

        public int? Responsibility { get; set; }

        public int? Punctuality { get; set; }

        public string? Comment { get; set; }

        public Rating(int id,
            int fromId,
            int toId,
            int social,
            int skills,
            int? responsibility,
            int? punctuality,
            string? comment)
        {
            this.Id = id;
            this.FromId = fromId;
            this.ToId = toId;
            this.Social = social;
            this.Skills = skills;
            this.Responsibility = responsibility;
            this.Punctuality = punctuality;
            this.Comment = comment;
        }
    }
}
