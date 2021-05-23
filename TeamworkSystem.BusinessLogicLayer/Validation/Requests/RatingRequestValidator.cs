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
                .LessThanOrEqualTo(5)
                .WithMessage(rating => $"{nameof(rating.Social)} should be less than or equal to 5.");

            RuleFor(rating => rating.Skills)
                .NotEmpty()
                .WithMessage(rating => $"{nameof(rating.Skills)} can't be empty.")
                .GreaterThan(0)
                .WithMessage(rating => $"{nameof(rating.Skills)} should be greater than 0.")
                .LessThanOrEqualTo(5)
                .WithMessage(rating => $"{nameof(rating.Skills)} should be less than or equal to 5.");

            RuleFor(rating => rating.Responsibility)
                .NotEmpty()
                .WithMessage(rating => $"{nameof(rating.Responsibility)} can't be empty.")
                .GreaterThan(0)
                .WithMessage(rating => $"{nameof(rating.Responsibility)} should be greater than 0.")
                .LessThanOrEqualTo(5)
                .WithMessage(rating => $"{nameof(rating.Responsibility)} should be less than or equal to 5.");

            RuleFor(rating => rating.Punctuality)
                .NotEmpty()
                .WithMessage(rating => $"{nameof(rating.Punctuality)} can't be empty.")
                .GreaterThan(0)
                .WithMessage(rating => $"{nameof(rating.Punctuality)} should be greater than 0.")
                .LessThanOrEqualTo(5)
                .WithMessage(rating => $"{nameof(rating.Punctuality)} should be less than or equal to 5.");
        }
    }
}
