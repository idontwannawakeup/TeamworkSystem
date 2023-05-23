namespace TeamworkSystem.Identity.People.BusinessLogic.Common.Models.Requests;

public class UserSignInRequest
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
}
