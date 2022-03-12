using System.Linq.Expressions;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Core.DataAccess.Filters.Tickets;

public class StatusCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public StatusCriterion(TicketsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Status);

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.Status == _parameters.Status;
}
