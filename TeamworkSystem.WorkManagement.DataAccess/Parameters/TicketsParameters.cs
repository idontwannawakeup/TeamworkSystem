using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Shared.Parameters;
using TeamworkSystem.WorkManagement.DataAccess.Entities;

namespace TeamworkSystem.WorkManagement.DataAccess.Parameters;

public class TicketsParameters : QueryStringParameters, IFilterParameters<Ticket>
{
    public Guid? ProjectId { get; set; }
    public Guid? ExecutorId { get; set; }
    public string? Title { get; set; }
    public string? Status { get; set; }
}
