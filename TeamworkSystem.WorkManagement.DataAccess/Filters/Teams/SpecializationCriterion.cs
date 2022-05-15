using System.Linq.Expressions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.WorkManagement.DataAccess.Entities;
using TeamworkSystem.WorkManagement.DataAccess.Parameters;

namespace TeamworkSystem.WorkManagement.DataAccess.Filters.Teams;

public class SpecializationCriterion : IFilterCriterion<Team>
{
    private readonly TeamsParameters _parameters;

    public SpecializationCriterion(TeamsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Specialization);

    public Expression<Func<Team, bool>> Expression =>
        team => team.Specialization == _parameters.Specialization;
}
