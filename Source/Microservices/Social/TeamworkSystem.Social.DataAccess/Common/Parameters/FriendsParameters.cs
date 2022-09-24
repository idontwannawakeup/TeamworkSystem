using TeamworkSystem.Shared.Parameters;

namespace TeamworkSystem.Social.DataAccess.Common.Parameters;

public class FriendsParameters : QueryStringParameters
{
    public string? LastName { get; set; }
}
