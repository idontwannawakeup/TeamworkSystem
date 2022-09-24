namespace TeamworkSystem.WebClient.Exceptions;

public class ValidationException : Exception
{
    public Dictionary<string, List<string>> Errors { get; }

    public ValidationException(Dictionary<string, List<string>> errors) => Errors = errors;
}
