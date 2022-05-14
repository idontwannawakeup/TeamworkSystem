using System.Linq.Expressions;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Interfaces.Filters;

namespace TeamworkSystem.Core.DataAccess.Filters.Projects;

public class TeamMemberIdCriterion : IFilterCriterion<Project>
{
    private readonly ProjectsParameters _parameters;

    public TeamMemberIdCriterion(ProjectsParameters parameters) => _parameters = parameters;

    public bool Condition => _parameters.TeamMemberId is not null;

    public Expression<Func<Project, bool>> Expression => project =>
        project.Team.Members.Any(user => user.Id == _parameters.TeamMemberId);
}
