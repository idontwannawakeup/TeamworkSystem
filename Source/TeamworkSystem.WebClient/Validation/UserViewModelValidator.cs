using FluentValidation;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Validation;

public class UserViewModelValidator : AbstractValidator<UserViewModel>
{
    public UserViewModelValidator()
    {
        RuleFor(request => request.Email)
            .EmailAddress()
            .WithMessage("Wrong email address.");

        RuleFor(request => request.FirstName)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.FirstName)} can't be empty.")
            .MaximumLength(50)
            .WithMessage(request => $"{nameof(request.FirstName)} should be less than 50 characters.");

        RuleFor(request => request.LastName)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.LastName)} can't be empty.")
            .MaximumLength(50)
            .WithMessage(request => $"{nameof(request.LastName)} should be less than 50 characters.");

        RuleFor(request => request.Profession)
            .MaximumLength(50)
            .WithMessage(request => $"{nameof(request.Profession)} should be less than 50 characters.");

        RuleFor(request => request.Specialization)
            .MaximumLength(50)
            .WithMessage(request => $"{nameof(request.Specialization)} should be less than 50 characters.");
    }
}
