using System.Linq.Expressions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.WorkManagement.DataAccess.Entities;
using TeamworkSystem.WorkManagement.DataAccess.Parameters;

namespace TeamworkSystem.WorkManagement.DataAccess.Filters.Projects;

public class TitleCriterion : IFilterCriterion<Project>
{
    private readonly ProjectsParameters _parameters;

    public TitleCriterion(ProjectsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Title);

    public Expression<Func<Project, bool>> Expression =>
        project => project.Title.Contains(_parameters.Title!);
}
