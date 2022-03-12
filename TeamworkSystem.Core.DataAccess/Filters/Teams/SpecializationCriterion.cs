using System.Linq.Expressions;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Core.DataAccess.Filters.Teams;

public class SpecializationCriterion : IFilterCriterion<Team>
{
    private readonly TeamsParameters _parameters;

    public SpecializationCriterion(TeamsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Specialization);

    public Expression<Func<Team, bool>> Expression =>
        team => team.Specialization == _parameters.Specialization;
}
