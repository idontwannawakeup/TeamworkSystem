namespace TeamworkSystem.WebClient.ViewModels
{
    public class TeamViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Specialization { get; set; }

        public UserViewModel Leader { get; set; }
    }
}
