using System.Linq.Expressions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.WorkManagement.Domain.Entities;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Persistence.Filters.Tickets;

public class ProjectIdCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public ProjectIdCriterion(TicketsParameters parameters) => _parameters = parameters;

    public bool Condition => _parameters.ProjectId is not null;

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.ProjectId == _parameters.ProjectId;
}
