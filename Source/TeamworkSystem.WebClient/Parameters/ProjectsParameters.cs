namespace TeamworkSystem.WebClient.Parameters;

public class ProjectsParameters : QueryStringParameters
{
    public Guid? TeamId { get; set; }

    public Guid? TeamMemberId { get; set; }

    public string Title { get; set; }
}
