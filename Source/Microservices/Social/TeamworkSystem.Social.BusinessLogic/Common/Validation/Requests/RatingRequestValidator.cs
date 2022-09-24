using FluentValidation;
using TeamworkSystem.Social.BusinessLogic.Common.Models.Requests;

namespace TeamworkSystem.Social.BusinessLogic.Common.Validation.Requests;

public class RatingRequestValidator : AbstractValidator<RatingRequest>
{
    public RatingRequestValidator()
    {
        const int leftBound = 1;
        const int rightBound = 5;

        RuleFor(rating => rating.FromId)
            .NotEmpty()
            .WithMessage(rating => $"{nameof(rating.FromId)} can't be empty.");

        RuleFor(rating => rating.ToId)
            .NotEmpty()
            .WithMessage(rating => $"{nameof(rating.ToId)} can't be empty.");

        RuleFor(rating => rating.Social)
            .NotEmpty()
            .WithMessage(rating => $"{nameof(rating.Social)} can't be empty.")
            .GreaterThanOrEqualTo(leftBound)
            .WithMessage(rating =>
                $"{nameof(rating.Social)} should be greater than or equal to {leftBound}.")
            .LessThanOrEqualTo(rightBound)
            .WithMessage(rating =>
                $"{nameof(rating.Social)} should be less than or equal to {rightBound}.");

        RuleFor(rating => rating.Skills)
            .NotEmpty()
            .WithMessage(rating => $"{nameof(rating.Skills)} can't be empty.")
            .GreaterThanOrEqualTo(leftBound)
            .WithMessage(rating =>
                $"{nameof(rating.Skills)} should be greater than or equal to {leftBound}.")
            .LessThanOrEqualTo(rightBound)
            .WithMessage(rating =>
                $"{nameof(rating.Skills)} should be less than or equal to {rightBound}.");

        RuleFor(rating => rating.Responsibility)
            .NotEmpty()
            .WithMessage(rating => $"{nameof(rating.Responsibility)} can't be empty.")
            .GreaterThanOrEqualTo(leftBound)
            .WithMessage(rating =>
                $"{nameof(rating.Responsibility)} should be greater than or equal to {leftBound}.")
            .LessThanOrEqualTo(rightBound)
            .WithMessage(rating =>
                $"{nameof(rating.Responsibility)} should be less than or equal to {rightBound}.");

        RuleFor(rating => rating.Punctuality)
            .NotEmpty()
            .WithMessage(rating => $"{nameof(rating.Punctuality)} can't be empty.")
            .GreaterThanOrEqualTo(leftBound)
            .WithMessage(rating =>
                $"{nameof(rating.Punctuality)} should be greater than or equal to {leftBound}.")
            .LessThanOrEqualTo(rightBound)
            .WithMessage(rating =>
                $"{nameof(rating.Punctuality)} should be less than or equal to {rightBound}.");
    }
}
