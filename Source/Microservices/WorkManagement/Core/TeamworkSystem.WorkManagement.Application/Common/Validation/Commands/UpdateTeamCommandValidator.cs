using FluentValidation;
using TeamworkSystem.WorkManagement.Application.Features.Teams.Commands.UpdateTeam;

namespace TeamworkSystem.WorkManagement.Application.Common.Validation.Commands;

public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
{
    public UpdateTeamCommandValidator()
    {
        RuleFor(team => team.Id)
            .NotEmpty()
            .WithMessage(team => $"{nameof(team.Id)} can't be empty.");

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
