using System;
using FluentValidation;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;

namespace TeamworkSystem.BusinessLogicLayer.Validation.Requests
{
    public class TicketRequestValidtor : AbstractValidator<TicketRequest>
    {
        public TicketRequestValidtor()
        {
            RuleFor(ticket => ticket.ProjectId)
                .NotEmpty()
                .WithMessage(ticket => $"{nameof(ticket.ProjectId)} can't be empty.");

            RuleFor(ticket => ticket.Title)
                .NotEmpty()
                .WithMessage(ticket => $"{nameof(ticket.Title)} can't be empty.")
                .MaximumLength(50)
                .WithMessage(ticket => $"{nameof(ticket.Title)} should be less than 50 characters.");

            RuleFor(ticket => ticket.Type)
                .MaximumLength(50)
                .WithMessage(ticket => $"{nameof(ticket.Type)} should be less than 50 characters.");

            RuleFor(ticket => ticket.Description)
                .NotEmpty()
                .WithMessage(ticket => $"{nameof(ticket.Description)} can't be empty.");

            RuleFor(ticket => ticket.Status)
                .NotEmpty()
                .WithMessage(ticket => $"{nameof(ticket.Status)} can't be empty.")
                .MaximumLength(50)
                .WithMessage(ticket => $"{nameof(ticket.Status)} should be less than 50 characters.");

            RuleFor(ticket => ticket.Priority)
                .NotEmpty()
                .WithMessage(ticket => $"{nameof(ticket.Priority)} can't be empty.")
                .MaximumLength(50)
                .WithMessage(ticket => $"{nameof(ticket.Priority)} should be less than 50 characters.");

            RuleFor(ticket => ticket.Deadline)
                .GreaterThan(DateTime.Now)
                .WithMessage(ticket => $"{ticket.Deadline} should be later than now.");
        }
    }
}
