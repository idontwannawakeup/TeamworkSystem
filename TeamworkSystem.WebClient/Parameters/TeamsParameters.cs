namespace TeamworkSystem.WebClient.Parameters;

public class TeamsParameters : QueryStringParameters
{
    public Guid? UserId { get; set; }

    public string Name { get; set; }

    public string Specialization { get; set; }
}
