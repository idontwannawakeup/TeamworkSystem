using System.Linq.Expressions;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Filters.Tickets;

public class ExecutorIdCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public ExecutorIdCriterion(TicketsParameters parameters) =>
        _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.ExecutorId);

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.ExecutorId == _parameters.ExecutorId;
}
