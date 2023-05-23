using System.Linq.Expressions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.WorkManagement.Domain.Entities;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Persistence.Common.Filters.Tickets;

public class ExecutorIdCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public ExecutorIdCriterion(TicketsParameters parameters) =>
        _parameters = parameters;

    public bool Condition => _parameters.ExecutorId is not null;

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.ExecutorId == _parameters.ExecutorId;
}
