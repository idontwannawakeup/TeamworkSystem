using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Shared.Parameters;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Domain.Parameters;

public class TicketsParameters : QueryStringParameters, IFilterParameters<Ticket>
{
    public Guid? ProjectId { get; set; }
    public Guid? ExecutorId { get; set; }
    public string? Title { get; set; }
    public string? Status { get; set; }
}
