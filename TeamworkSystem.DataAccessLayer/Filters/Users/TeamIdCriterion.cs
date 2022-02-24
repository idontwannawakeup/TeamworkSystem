using System.Linq.Expressions;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Filters.Users;

public class TeamIdCriterion : IFilterCriterion<User>
{
    private readonly UsersParameters _parameters;

    public TeamIdCriterion(UsersParameters parameters) => _parameters = parameters;

    public bool Condition => _parameters.TeamId is not null or 0;

    public Expression<Func<User, bool>> Expression =>
        user => user.Teams.Any(team => team.Id == _parameters.TeamId);
}
