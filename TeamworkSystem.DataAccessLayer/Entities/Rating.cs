namespace TeamworkSystem.DataAccessLayer.Entities
{
    public class Rating
    {
        public int Id { get; set; }

        public string FromId { get; set; } = default!;

        public string ToId { get; set; } = default!;

        public int Social { get; set; }

        public int Skills { get; set; }

        public int Responsibility { get; set; }

        public int Punctuality { get; set; }

        public string? Comment { get; set; }

        public User From { get; set; } = default!;

        public User To { get; set; } = default!;
    }
}
