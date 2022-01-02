using Microsoft.AspNetCore.Identity;

namespace TeamworkSystem.DataAccessLayer.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string? Profession { get; set; }

        public string? Specialization { get; set; }

        public string? Avatar { get; set; }

        public List<Team> Teams { get; set; } = default!;

        public List<Ticket> Tickets { get; set; } = default!;

        public List<Rating> MyRatings { get; set; } = default!;

        public List<Rating> RatingsFromMe { get; set; } = default!;

        public List<User> Friends { get; set; } = default!;

        public List<User> FriendForUsers { get; set; } = default!;
    }
}
