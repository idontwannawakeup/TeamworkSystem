using System.Collections.Generic;

namespace TeamworkSystem.BusinessLogicLayer.DTO.Responses
{
    public class ErrorResponse
    {
        public List<string> Errors { get; } = new();

        public ErrorResponse(string error) =>
            Errors = new()
            {
                error
            };

        public ErrorResponse()
        {
        }
    }
}
