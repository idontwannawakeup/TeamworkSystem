using FluentValidation;
using TeamworkSystem.Social.BusinessLogic.DTO.Requests;

namespace TeamworkSystem.Social.BusinessLogic.Validation.Requests;

public class FriendsRequestValidator : AbstractValidator<FriendsRequest>
{
    public FriendsRequestValidator()
    {
        RuleFor(request => request.FirstId)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.FirstId)} can't be empty.");

        RuleFor(request => request.SecondId)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.SecondId)} can't be empty.");
    }
}
