using System.Linq.Expressions;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Core.DataAccess.Filters.Tickets;

public class TitleCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public TitleCriterion(TicketsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Title);

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.Title.Contains(_parameters.Title!);
}
