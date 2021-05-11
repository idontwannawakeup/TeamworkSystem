namespace TeamworkSystem.WebClient.ViewModels
{
    public class RatingViewModel
    {
        public int Id { get; set; }

        public int Social { get; set; }

        public int Skills { get; set; }

        public int? Responsibility { get; set; }

        public int? Punctuality { get; set; }

        public string Comment { get; set; }

        public UserViewModel From { get; set; }

        public UserViewModel To { get; set; }
    }
}
