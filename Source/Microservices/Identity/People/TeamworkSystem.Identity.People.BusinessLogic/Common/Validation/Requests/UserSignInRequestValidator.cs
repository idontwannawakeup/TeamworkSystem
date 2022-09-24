using FluentValidation;
using TeamworkSystem.Identity.People.BusinessLogic.Common.Models.Requests;

namespace TeamworkSystem.Identity.People.BusinessLogic.Common.Validation.Requests;

public class UserSignInRequestValidator : AbstractValidator<UserSignInRequest>
{
    public UserSignInRequestValidator()
    {
        RuleFor(request => request.UserName)
            .NotEmpty()
            .WithMessage("UserName can't be empty.");

        RuleFor(request => request.Password)
            .NotEmpty()
            .WithMessage("Password can't be empty.");
    }
}
