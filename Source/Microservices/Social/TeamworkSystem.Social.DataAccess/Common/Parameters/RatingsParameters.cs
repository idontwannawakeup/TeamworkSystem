using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Shared.Parameters;
using TeamworkSystem.Social.DataAccess.Data.Entities;

namespace TeamworkSystem.Social.DataAccess.Common.Parameters;

public class RatingsParameters : QueryStringParameters, IFilterParameters<Rating>
{
    public Guid? RatedUserId { get; set; }
}
