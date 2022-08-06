using System.Linq.Expressions;
using TeamworkSystem.Identity.Persistence.People.Entities;
using TeamworkSystem.Identity.Persistence.People.Parameters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Identity.Persistence.People.Filters.Users;

public class LastNameCriterion : IFilterCriterion<User>
{
    private readonly UsersParameters _parameters;

    public LastNameCriterion(UsersParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.LastName);

    public Expression<Func<User, bool>> Expression =>
        user => user.LastName.Contains(_parameters.LastName!);
}
