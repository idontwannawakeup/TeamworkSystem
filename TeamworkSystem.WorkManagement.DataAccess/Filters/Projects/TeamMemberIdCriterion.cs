using System.Linq.Expressions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.WorkManagement.DataAccess.Entities;
using TeamworkSystem.WorkManagement.DataAccess.Parameters;

namespace TeamworkSystem.WorkManagement.DataAccess.Filters.Projects;

public class TeamMemberIdCriterion : IFilterCriterion<Project>
{
    private readonly ProjectsParameters _parameters;

    public TeamMemberIdCriterion(ProjectsParameters parameters) => _parameters = parameters;

    public bool Condition => _parameters.TeamMemberId is not null;

    public Expression<Func<Project, bool>> Expression => project =>
        project.Team.Members.Any(user => user.Id == _parameters.TeamMemberId);
}
