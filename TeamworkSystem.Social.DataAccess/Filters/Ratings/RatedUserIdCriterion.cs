using System.Linq.Expressions;
using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Social.DataAccess.Entities;
using TeamworkSystem.Social.DataAccess.Parameters;

namespace TeamworkSystem.Social.DataAccess.Filters.Ratings;

public class RatedUserIdCriterion : IFilterCriterion<Rating>
{
    private readonly RatingsParameters _parameters;

    public RatedUserIdCriterion(RatingsParameters parameters) => _parameters = parameters;

    public bool Condition => _parameters.RatedUserId is not null;

    public Expression<Func<Rating, bool>> Expression =>
        rating => rating.ToId == _parameters.RatedUserId;
}
