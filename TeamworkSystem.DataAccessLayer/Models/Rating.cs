using TeamworkSystem.DataAccessLayer.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Models
{
    public class Rating : IEntity
    {
        public int From { get; set; }
        
        public int To { get; set; }
        
        public int Social { get; set; }
        
        public int Skills { get; set; }
        
        public int? Responsibility { get; set; }
        
        public int? Punctuality { get; set; }
        
        public string? Comment { get; set; }

        public Rating(int @from,
            int to,
            int social,
            int skills,
            int? responsibility,
            int? punctuality,
            string? comment)
        {
            this.From = @from;
            this.To = to;
            this.Social = social;
            this.Skills = skills;
            this.Responsibility = responsibility;
            this.Punctuality = punctuality;
            this.Comment = comment;
        }
    }
}