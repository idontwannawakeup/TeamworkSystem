using System;
using System.Threading.Tasks;
using MudBlazor;
using TeamworkSystem.WebClient.Exceptions;

namespace TeamworkSystem.WebClient.Extensions
{
    public class RequestErrorsHandler
    {
        private readonly ISnackbar snackbar;

        public async Task HandleRequestAsync(Func<Task> func)
        {
            try
            {
                await func?.Invoke();
            }
            catch (ValidationException e)
            {
                foreach (var (property, errors) in e.Errors)
                {
                    foreach (var error in errors)
                    {
                        snackbar.Add(error, Severity.Error);
                    }
                }
            }
            catch (EntityNotFoundException e)
            {
                snackbar.Add(e.Error, Severity.Error);
            }
            catch (ServerResponseException e)
            {
                snackbar.Add(e.Error, Severity.Error);
            }
        }

        public RequestErrorsHandler(ISnackbar snackbar) => this.snackbar = snackbar;
    }
}
