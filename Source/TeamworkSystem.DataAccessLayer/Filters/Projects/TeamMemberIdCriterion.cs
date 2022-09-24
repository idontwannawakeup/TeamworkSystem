using System.Linq.Expressions;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Filters.Projects;

public class TeamMemberIdCriterion : IFilterCriterion<Project>
{
    private readonly ProjectsParameters _parameters;

    public TeamMemberIdCriterion(ProjectsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.TeamMemberId);

    public Expression<Func<Project, bool>> Expression => project =>
        project.Team.Members.Any(user => user.Id == _parameters.TeamMemberId);
}
