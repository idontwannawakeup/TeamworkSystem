namespace TeamworkSystem.WebClient.ViewModels
{
    public class FriendsViewModel
    {
        public Guid FirstId { get; set; }

        public Guid SecondId { get; set; }

        public UserViewModel Second { get; set; }
    }
}
