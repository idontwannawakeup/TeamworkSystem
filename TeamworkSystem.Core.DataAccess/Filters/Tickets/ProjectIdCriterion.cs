using System.Linq.Expressions;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Core.DataAccess.Filters.Tickets;

public class ProjectIdCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public ProjectIdCriterion(TicketsParameters parameters) => _parameters = parameters;

    public bool Condition => _parameters.ProjectId is not null;

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.ProjectId == _parameters.ProjectId;
}
