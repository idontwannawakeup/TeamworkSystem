using System.Net;
using TeamworkSystem.WebClient.Exceptions;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Extensions
{
    public static class StatusCodeHandler
    {
        private static readonly Dictionary<HttpStatusCode, Action<string>> StatusCodesHandlers = new()
        {
            {
                HttpStatusCode.NotFound,
                responseBody => throw new EntityNotFoundException(
                    responseBody.Deserialize<ErrorViewModel>().Message)
            },
            {
                HttpStatusCode.BadRequest,
                responseBody => throw new ValidationException(
                    responseBody.Deserialize<ValidationErrorViewModel>().Errors)
            },
            {
                HttpStatusCode.InternalServerError,
                responseBody => throw new ServerResponseException(
                    responseBody.Deserialize<ErrorViewModel>().Message)
            }
        };

        public static void TryHandleStatusCode(HttpStatusCode statusCode, string responseBody)
        {
            if (StatusCodesHandlers.TryGetValue(statusCode, out var statusCodeHandler))
            {
                statusCodeHandler(responseBody);
            }
        }
    }
}
