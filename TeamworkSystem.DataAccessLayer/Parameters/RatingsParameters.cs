using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces.Filters;

namespace TeamworkSystem.DataAccessLayer.Parameters;

public class RatingsParameters : QueryStringParameters, IFilterParameters<Rating>
{
    public string? RatedUserId { get; set; }
}
