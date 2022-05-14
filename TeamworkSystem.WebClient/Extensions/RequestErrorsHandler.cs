using MudBlazor;
using TeamworkSystem.WebClient.Exceptions;

namespace TeamworkSystem.WebClient.Extensions
{
    public class RequestErrorsHandler
    {
        private readonly ISnackbar _snackbar;

        public async Task HandleRequestAsync(Func<Task> func)
        {
            try
            {
                await func?.Invoke()!;
            }
            catch (ValidationException e)
            {
                foreach (var error in e.Errors.Values.SelectMany(errors => errors))
                {
                    _snackbar.Add(error, Severity.Error);
                }
            }
            catch (EntityNotFoundException e)
            {
                _snackbar.Add(e.Error, Severity.Error);
            }
            catch (ServerResponseException e)
            {
                _snackbar.Add(e.Error, Severity.Error);
            }
        }

        public RequestErrorsHandler(ISnackbar snackbar) => _snackbar = snackbar;
    }
}
