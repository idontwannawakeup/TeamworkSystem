using System.Linq.Expressions;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Filters.Teams;

public class SpecializationCriterion : IFilterCriterion<Team>
{
    private readonly TeamsParameters _parameters;

    public SpecializationCriterion(TeamsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Specialization);

    public Expression<Func<Team, bool>> Expression =>
        team => team.Specialization == _parameters.Specialization;
}
