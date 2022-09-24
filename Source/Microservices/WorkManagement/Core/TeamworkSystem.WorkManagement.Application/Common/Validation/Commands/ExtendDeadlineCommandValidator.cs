using FluentValidation;
using TeamworkSystem.WorkManagement.Application.Tickets.Commands.ExtendDeadline;

namespace TeamworkSystem.WorkManagement.Application.Common.Validation.Commands;

public class ExtendDeadlineCommandValidator : AbstractValidator<ExtendDeadlineCommand>
{
    public ExtendDeadlineCommandValidator()
    {
        RuleFor(ticket => ticket.Id)
            .NotEmpty()
            .WithMessage(ticket => $"{nameof(ticket.Id)} can't be empty.");

        RuleFor(ticket => ticket.Deadline)
            .GreaterThan(DateTime.Now)
            .WithMessage(ticket => $"{nameof(ticket.Deadline)} should be later than now.");
    }
}
