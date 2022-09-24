namespace TeamworkSystem.WebClient.Parameters;

public class TicketsParameters : QueryStringParameters
{
    public Guid? ProjectId { get; set; }

    public Guid? ExecutorId { get; set; }

    public string Title { get; set; }

    public string Status { get; set; }
}
