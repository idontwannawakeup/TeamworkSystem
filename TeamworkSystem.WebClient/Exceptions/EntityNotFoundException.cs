namespace TeamworkSystem.WebClient.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string error) => Error = error;

    public string Error { get; set; }
}
