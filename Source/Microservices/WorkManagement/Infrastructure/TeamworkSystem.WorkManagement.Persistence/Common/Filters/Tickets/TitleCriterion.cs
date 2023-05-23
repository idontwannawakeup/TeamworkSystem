using System.Linq.Expressions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.WorkManagement.Domain.Entities;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Persistence.Common.Filters.Tickets;

public class TitleCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public TitleCriterion(TicketsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Title);

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.Title.Contains(_parameters.Title!);
}
