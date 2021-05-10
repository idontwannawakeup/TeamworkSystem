namespace TeamworkSystem.DataAccessLayer.Parameters
{
    public class ProjectsParameters : QueryStringParameters
    {
        public int? TeamId { get; set; }

        public string TeamMemberId { get; set; }
    }
}
