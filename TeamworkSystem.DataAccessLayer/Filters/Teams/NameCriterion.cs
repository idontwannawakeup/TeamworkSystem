using System.Linq.Expressions;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Filters.Teams;

public class NameCriterion : IFilterCriterion<Team>
{
    private readonly TeamsParameters _parameters;

    public NameCriterion(TeamsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Name);

    public Expression<Func<Team, bool>> Expression =>
        team => team.Name.Contains(_parameters.Name!);
}
