using System.Linq.Expressions;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Filters.Teams;

public class MemberIdCriterion : IFilterCriterion<Team>
{
    private readonly TeamsParameters _parameters;

    public MemberIdCriterion(TeamsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.UserId);

    public Expression<Func<Team, bool>> Expression =>
        team => team.Members.Any(user => user.Id == _parameters.UserId);
}
