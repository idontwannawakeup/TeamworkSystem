using FluentValidation;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Validation;

public class UserSignInViewModelValidator : AbstractValidator<UserSignInViewModel>
{
    public UserSignInViewModelValidator()
    {
        RuleFor(request => request.UserName)
            .NotEmpty()
            .WithMessage("UserName can't be empty.");

        RuleFor(request => request.Password)
            .NotEmpty()
            .WithMessage("Password can't be empty.");
    }
}
