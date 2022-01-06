namespace TeamworkSystem.BusinessLogicLayer.DTO.Responses;

public class ErrorResponse
{
    public List<string> Errors { get; } = new();

    public ErrorResponse(string error) => Errors = new List<string> { error };

    public ErrorResponse()
    {
    }
}
