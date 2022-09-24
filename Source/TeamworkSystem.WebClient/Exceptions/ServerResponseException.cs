namespace TeamworkSystem.WebClient.Exceptions;

public class ServerResponseException : Exception
{
    public string Error { get; set; }

    public ServerResponseException(string error) => Error = error;
}
