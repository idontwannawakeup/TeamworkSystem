using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;

namespace TeamworkSystem.DataAccessLayer.Parameters;

public class TicketsParameters : QueryStringParameters, IFilterParameters<Ticket>
{
    public int? ProjectId { get; set; }
    public string? ExecutorId { get; set; }
    public string? Title { get; set; }
    public string? Status { get; set; }
}
