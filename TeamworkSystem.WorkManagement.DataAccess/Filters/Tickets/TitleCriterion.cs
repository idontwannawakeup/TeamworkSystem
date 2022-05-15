using System.Linq.Expressions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.WorkManagement.DataAccess.Entities;
using TeamworkSystem.WorkManagement.DataAccess.Parameters;

namespace TeamworkSystem.WorkManagement.DataAccess.Filters.Tickets;

public class TitleCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public TitleCriterion(TicketsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Title);

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.Title.Contains(_parameters.Title!);
}
