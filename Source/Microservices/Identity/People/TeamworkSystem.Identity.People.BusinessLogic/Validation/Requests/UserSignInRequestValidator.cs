using FluentValidation;
using TeamworkSystem.Identity.People.BusinessLogic.DTO.Requests;

namespace TeamworkSystem.Identity.People.BusinessLogic.Validation.Requests;

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
