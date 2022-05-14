namespace TeamworkSystem.WebClient.Parameters
{
    public class UsersParameters : QueryStringParameters
    {
        public Guid? TeamId { get; set; }

        public string LastName { get; set; }
    }
}
