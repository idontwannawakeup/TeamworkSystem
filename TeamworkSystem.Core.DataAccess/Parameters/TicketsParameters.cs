using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Shared.Parameters;

namespace TeamworkSystem.Core.DataAccess.Parameters;

public class TicketsParameters : QueryStringParameters, IFilterParameters<Ticket>
{
    public int? ProjectId { get; set; }
    public string? ExecutorId { get; set; }
    public string? Title { get; set; }
    public string? Status { get; set; }
}
