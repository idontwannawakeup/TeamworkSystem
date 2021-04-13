namespace TeamworkSystem.BusinessLogicLayer.DTO.Requests
{
    public class ProjectRequest
    {
        public int TeamId { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }
    }
}
