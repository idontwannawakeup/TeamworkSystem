using System.Linq.Expressions;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Filters.Ratings;

public class RatedUserIdCriterion : IFilterCriterion<Rating>
{
    private readonly RatingsParameters _parameters;

    public RatedUserIdCriterion(RatingsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.RatedUserId);

    public Expression<Func<Rating, bool>> Expression =>
        rating => rating.ToId == _parameters.RatedUserId;
}
