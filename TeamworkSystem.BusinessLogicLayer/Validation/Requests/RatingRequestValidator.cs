using FluentValidation;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;

namespace TeamworkSystem.BusinessLogicLayer.Validation.Requests
{
    public class RatingRequestValidator : AbstractValidator<RatingRequest>
    {
        public RatingRequestValidator()
        {
            RuleFor(rating => rating.FromId)
                .NotEmpty()
                .WithMessage(rating => $"{nameof(rating.FromId)} can't be empty.");

            RuleFor(rating => rating.ToId)
                .NotEmpty()
                .WithMessage(rating => $"{nameof(rating.ToId)} can't be empty.");

            RuleFor(rating => rating.Social)
                .NotEmpty()
                .WithMessage(rating => $"{nameof(rating.Social)} can't be empty.")
                .GreaterThan(0)
                .WithMessage(rating => $"{nameof(rating.Social)} should be greater than 0.")
                .LessThanOrEqualTo(100)
                .WithMessage(rating => $"{nameof(rating.Social)} should be less than or equal to 100.");

            RuleFor(rating => rating.Skills)
                .NotEmpty()
                .WithMessage(rating => $"{nameof(rating.Skills)} can't be empty.")
                .GreaterThan(0)
                .WithMessage(rating => $"{nameof(rating.Skills)} should be greater than 0.")
                .LessThanOrEqualTo(100)
                .WithMessage(rating => $"{nameof(rating.Skills)} should be less than or equal to 100.");

            RuleFor(rating => rating.Responsibility)
                .GreaterThan(0)
                .When(rating => rating.Responsibility is not null)
                .WithMessage(rating => $"{nameof(rating.Responsibility)} should be greater than 0.")
                .LessThanOrEqualTo(100)
                .When(rating => rating.Responsibility is not null)
                .WithMessage(rating => $"{nameof(rating.Responsibility)} should be less than or equal to 100.");

            RuleFor(rating => rating.Punctuality)
                .GreaterThan(0)
                .When(rating => rating.Punctuality is not null)
                .WithMessage(rating => $"{nameof(rating.Punctuality)} should be greater than 0.")
                .LessThanOrEqualTo(100)
                .When(rating => rating.Punctuality is not null)
                .WithMessage(rating => $"{nameof(rating.Punctuality)} should be less than or equal to 100.");
        }
    }
}
