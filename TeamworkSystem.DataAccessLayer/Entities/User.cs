using System.Collections.Generic;

namespace TeamworkSystem.DataAccessLayer.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Profession { get; set; }

        public string Specialization { get; set; }

        public List<Team> Teams { get; set; }

        public List<Ticket> Tickets { get; set; }
        
        public List<Rating> MyRatings { get; set; }
        
        public List<Rating> RatingsFromMe { get; set; }
        
        public List<User> FriendsFirst { get; set; }
        
        public List<User> FriendsSecond { get; set; }
    }
}
