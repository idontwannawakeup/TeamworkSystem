using FluentValidation;
using TeamworkSystem.Identity.People.BusinessLogic.DTO.Requests;

namespace TeamworkSystem.Identity.People.BusinessLogic.Validation.Requests;

public class UserSignUpRequestValidator : AbstractValidator<UserSignUpRequest>
{
    public UserSignUpRequestValidator()
    {
        RuleFor(request => request.UserName)
            .NotEmpty()
            .WithMessage("UserName can't be empty.");

        RuleFor(request => request.Email)
            .EmailAddress()
            .WithMessage("Wrong email address.");

        RuleFor(request => request.Password)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.Password)} can't be empty.")
            .Must(password => password is not null && password.Any(char.IsUpper))
            .WithMessage(request =>
                $"{nameof(request.Password)} must contain an uppercase character.")
            .Must(password => password is not null && password.Any(char.IsLower))
            .WithMessage(request =>
                $"{nameof(request.Password)} must contain a lowercase character.")
            .Must(password => password is not null && password.Any(char.IsDigit))
            .WithMessage(request => $"{nameof(request.Password)} must contain a digit.");

        RuleFor(request => request.FirstName)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.FirstName)} can't be empty.")
            .MaximumLength(50)
            .WithMessage(request =>
                $"{nameof(request.FirstName)} should be less than 50 characters.");

        RuleFor(request => request.LastName)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.LastName)} can't be empty.")
            .MaximumLength(50)
            .WithMessage(
                request => $"{nameof(request.LastName)} should be less than 50 characters.");

        RuleFor(request => request.Profession)
            .MaximumLength(50)
            .WithMessage(request =>
                $"{nameof(request.Profession)} should be less than 50 characters.");

        RuleFor(request => request.Specialization)
            .MaximumLength(50)
            .WithMessage(request =>
                $"{nameof(request.Specialization)} should be less than 50 characters.");
    }
}
