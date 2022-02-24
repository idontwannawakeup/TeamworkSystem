using System.Linq.Expressions;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Filters.Tickets;

public class StatusCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public StatusCriterion(TicketsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Status);

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.Status == _parameters.Status;
}
