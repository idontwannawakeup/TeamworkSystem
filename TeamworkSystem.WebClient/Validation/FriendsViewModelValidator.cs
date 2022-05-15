using FluentValidation;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Validation;

public class FriendsViewModelValidator : AbstractValidator<FriendsViewModel>
{
    public FriendsViewModelValidator()
    {
        RuleFor(request => request.FirstId)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.FirstId)} can't be empty.");

        RuleFor(request => request.SecondId)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.SecondId)} can't be empty.");

        RuleFor(request => request.Second)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.Second)} can't be empty.");
    }
}
