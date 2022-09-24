using System.Linq.Expressions;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Filters.Users;

public class LastNameCriterion : IFilterCriterion<User>
{
    private readonly UsersParameters _parameters;

    public LastNameCriterion(UsersParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.LastName);

    public Expression<Func<User, bool>> Expression =>
        user => user.LastName.Contains(_parameters.LastName!);
}
