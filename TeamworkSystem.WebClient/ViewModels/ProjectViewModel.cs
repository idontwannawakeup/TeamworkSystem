namespace TeamworkSystem.WebClient.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public TeamViewModel Team { get; set; }
    }
}
