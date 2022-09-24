using System.Linq.Expressions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.WorkManagement.Domain.Entities;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Persistence.Filters.Projects;

public class TeamIdCriterion : IFilterCriterion<Project>
{
    private readonly ProjectsParameters _parameters;

    public TeamIdCriterion(ProjectsParameters parameters) => _parameters = parameters;

    public bool Condition => _parameters.TeamId is not null;

    public Expression<Func<Project, bool>> Expression =>
        project => project.TeamId == _parameters.TeamId;
}
