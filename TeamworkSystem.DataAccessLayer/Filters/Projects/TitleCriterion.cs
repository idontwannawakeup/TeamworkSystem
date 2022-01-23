using System.Linq.Expressions;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Filters.Projects;

public class TitleCriterion : IFilterCriterion<Project>
{
    private readonly ProjectsParameters _parameters;

    public TitleCriterion(ProjectsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Title);

    public Expression<Func<Project, bool>> Expression =>
        project => project.Title.Contains(_parameters.Title!);
}
