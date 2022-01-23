using System.Linq.Expressions;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Filters.Tickets;

public class TitleCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public TitleCriterion(TicketsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Title);

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.Title.Contains(_parameters.Title!);
}
