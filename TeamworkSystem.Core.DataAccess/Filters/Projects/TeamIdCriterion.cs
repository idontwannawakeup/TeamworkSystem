using System.Linq.Expressions;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Core.DataAccess.Filters.Projects;

public class TeamIdCriterion : IFilterCriterion<Project>
{
    private readonly ProjectsParameters _parameters;

    public TeamIdCriterion(ProjectsParameters parameters) => _parameters = parameters;

    public bool Condition => _parameters.TeamId is not null;

    public Expression<Func<Project, bool>> Expression =>
        project => project.TeamId == _parameters.TeamId;
}
