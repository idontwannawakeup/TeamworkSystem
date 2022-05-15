using System.Linq.Expressions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.WorkManagement.DataAccess.Entities;
using TeamworkSystem.WorkManagement.DataAccess.Parameters;

namespace TeamworkSystem.WorkManagement.DataAccess.Filters.Teams;

public class MemberIdCriterion : IFilterCriterion<Team>
{
    private readonly TeamsParameters _parameters;

    public MemberIdCriterion(TeamsParameters parameters) => _parameters = parameters;

    public bool Condition => _parameters.UserId is not null;

    public Expression<Func<Team, bool>> Expression =>
        team => team.Members.Any(user => user.Id == _parameters.UserId);
}
