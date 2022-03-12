using TeamworkSystem.Shared.Interfaces.Filters;
using TeamworkSystem.Shared.Parameters;
using TeamworkSystem.Social.DataAccess.Entities;

namespace TeamworkSystem.Social.DataAccess.Parameters;

public class RatingsParameters : QueryStringParameters, IFilterParameters<Rating>
{
    public string? RatedUserId { get; set; }
}
