﻿namespace TeamworkSystem.WebClient.Parameters
{
    public class UsersParameters : QueryStringParameters
    {
        public int? TeamId { get; set; }

        public string LastName { get; set; }
    }
}
