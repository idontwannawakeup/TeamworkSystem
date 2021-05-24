namespace TeamworkSystem.DataAccessLayer.Parameters
{
    public class TicketsParameters : QueryStringParameters
    {
        public int? ProjectId { get; set; }

        public string ExecutorId { get; set; }

        public string Title { get; set; }
    }
}
