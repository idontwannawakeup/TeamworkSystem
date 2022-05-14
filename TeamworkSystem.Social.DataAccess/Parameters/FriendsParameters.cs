using TeamworkSystem.Shared.Parameters;

namespace TeamworkSystem.Social.DataAccess.Parameters;

public class FriendsParameters : QueryStringParameters
{
    public string? LastName { get; set; }
}
