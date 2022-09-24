using FluentValidation;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;

namespace TeamworkSystem.BusinessLogicLayer.Validation.Requests;

public class TeamRequestValidator : AbstractValidator<TeamRequest>
{
    public TeamRequestValidator()
    {
        RuleFor(team => team.Name)
            .NotEmpty()
            .WithMessage(team => $"{nameof(team.Name)} can't be empty.")
            .MaximumLength(50)
            .WithMessage(team => $"{nameof(team.Name)} should be less than 50 characters.");

        RuleFor(team => team.LeaderId)
            .NotEmpty()
            .WithMessage(team => $"{nameof(team.LeaderId)} can't be empty.");

        RuleFor(team => team.Specialization)
            .MaximumLength(50)
            .WithMessage(
                team => $"{nameof(team.Specialization)} should be less than 50 characters.");
    }
}
