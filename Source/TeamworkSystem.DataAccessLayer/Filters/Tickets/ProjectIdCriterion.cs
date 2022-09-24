using System.Linq.Expressions;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Filters.Tickets;

public class ProjectIdCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public ProjectIdCriterion(TicketsParameters parameters) => _parameters = parameters;

    public bool Condition => _parameters.ProjectId is not null or 0;

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.ProjectId == _parameters.ProjectId;
}
