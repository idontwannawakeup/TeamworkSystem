using System.Linq.Expressions;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Core.DataAccess.Filters.Teams;

public class MemberIdCriterion : IFilterCriterion<Team>
{
    private readonly TeamsParameters _parameters;

    public MemberIdCriterion(TeamsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.UserId);

    public Expression<Func<Team, bool>> Expression =>
        team => team.Members.Any(user => user.Id == _parameters.UserId);
}
