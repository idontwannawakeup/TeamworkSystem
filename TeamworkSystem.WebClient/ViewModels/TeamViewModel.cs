namespace TeamworkSystem.WebClient.ViewModels
{
    public class TeamViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid LeaderId { get; set; }

        public string Specialization { get; set; }

        public string About { get; set; }

        public string Avatar { get; set; }

        public UserViewModel Leader { get; set; }
    }
}
