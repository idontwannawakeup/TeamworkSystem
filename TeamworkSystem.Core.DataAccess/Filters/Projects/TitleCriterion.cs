using System.Linq.Expressions;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Core.DataAccess.Filters.Projects;

public class TitleCriterion : IFilterCriterion<Project>
{
    private readonly ProjectsParameters _parameters;

    public TitleCriterion(ProjectsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Title);

    public Expression<Func<Project, bool>> Expression =>
        project => project.Title.Contains(_parameters.Title!);
}
