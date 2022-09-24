using FluentValidation;
using TeamworkSystem.WorkManagement.Application.Tickets.Commands.DeleteTicket;

namespace TeamworkSystem.WorkManagement.Application.Common.Validation.Commands;

public class DeleteTicketCommandValidator : AbstractValidator<DeleteTicketCommand>
{
    public DeleteTicketCommandValidator()
    {
        RuleFor(ticket => ticket.Id)
            .NotEmpty()
            .WithMessage(ticket => $"{nameof(ticket.Id)} can't be empty.");
    }
}
