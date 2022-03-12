using System.Linq.Expressions;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Core.DataAccess.Filters.Teams;

public class NameCriterion : IFilterCriterion<Team>
{
    private readonly TeamsParameters _parameters;

    public NameCriterion(TeamsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Name);

    public Expression<Func<Team, bool>> Expression =>
        team => team.Name.Contains(_parameters.Name!);
}
