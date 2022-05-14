namespace TeamworkSystem.WebClient.ViewModels
{
    public class TeamMemberViewModel
    {
        public Guid UserId { get; set; }

        public Guid TeamId { get; set; }

        public UserViewModel User { get; set; }
    }
}
