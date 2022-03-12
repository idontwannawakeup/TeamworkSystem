using System.Linq.Expressions;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Core.DataAccess.Filters.Tickets;

public class ExecutorIdCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public ExecutorIdCriterion(TicketsParameters parameters) =>
        _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.ExecutorId);

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.ExecutorId == _parameters.ExecutorId;
}
