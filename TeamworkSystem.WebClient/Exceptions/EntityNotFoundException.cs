using System;

namespace TeamworkSystem.WebClient.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string Error { get; set; }

        public EntityNotFoundException() : this(default)
        {
        }

        public EntityNotFoundException(string error) : base() =>
            Error = error;
    }
}
