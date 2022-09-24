using System.Linq.Expressions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.WorkManagement.Domain.Entities;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Persistence.Filters.Teams;

public class NameCriterion : IFilterCriterion<Team>
{
    private readonly TeamsParameters _parameters;

    public NameCriterion(TeamsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Name);

    public Expression<Func<Team, bool>> Expression =>
        team => team.Name.Contains(_parameters.Name!);
}
