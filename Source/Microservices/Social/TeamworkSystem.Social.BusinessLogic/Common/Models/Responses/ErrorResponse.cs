namespace TeamworkSystem.Social.BusinessLogic.Common.Models.Responses;

public class ErrorResponse
{
    public ErrorResponse()
    {
    }

    public ErrorResponse(string error) => Errors = new List<string> { error };

    public List<string> Errors { get; } = new();
}
