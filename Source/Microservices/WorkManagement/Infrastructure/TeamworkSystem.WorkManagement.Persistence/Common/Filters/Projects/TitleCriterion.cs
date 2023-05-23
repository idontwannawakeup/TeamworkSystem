using System.Linq.Expressions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.WorkManagement.Domain.Entities;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Persistence.Common.Filters.Projects;

public class TitleCriterion : IFilterCriterion<Project>
{
    private readonly ProjectsParameters _parameters;

    public TitleCriterion(ProjectsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Title);

    public Expression<Func<Project, bool>> Expression =>
        project => project.Title.Contains(_parameters.Title!);
}
