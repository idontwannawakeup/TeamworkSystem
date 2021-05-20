using System;

namespace TeamworkSystem.WebClient.Exceptions
{
    public class ServerResponseException : Exception
    {
        public string Error { get; set; }

        public ServerResponseException() : this(default)
        {
        }

        public ServerResponseException(string error) : base() =>
            Error = error;
    }
}
