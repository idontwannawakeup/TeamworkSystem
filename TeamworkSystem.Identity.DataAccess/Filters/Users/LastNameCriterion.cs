using System.Linq.Expressions;
using TeamworkSystem.Identity.DataAccess.Entities;
using TeamworkSystem.Identity.DataAccess.Parameters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Identity.DataAccess.Filters.Users;

public class LastNameCriterion : IFilterCriterion<User>
{
    private readonly UsersParameters _parameters;

    public LastNameCriterion(UsersParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.LastName);

    public Expression<Func<User, bool>> Expression =>
        user => user.LastName.Contains(_parameters.LastName!);
}
