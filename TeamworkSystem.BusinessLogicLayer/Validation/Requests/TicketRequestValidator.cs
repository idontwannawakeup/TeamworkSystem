using FluentValidation;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;

namespace TeamworkSystem.BusinessLogicLayer.Validation.Requests;

public class TicketRequestValidator : AbstractValidator<TicketRequest>
{
    public TicketRequestValidator()
    {
        var types = new List<string>
        {
            "Epic",
            "Task",
            "Bug"
        };

        var statuses = new List<string>
        {
            "Backlog",
            "Chosen For Development",
            "In Progress",
            "Done"
        };

        var priorities = new List<string>
        {
            "Low",
            "Medium",
            "High"
        };

        RuleFor(ticket => ticket.ProjectId)
            .NotEmpty()
            .WithMessage(ticket => $"{nameof(ticket.ProjectId)} can't be empty.");

        RuleFor(ticket => ticket.Title)
            .NotEmpty()
            .WithMessage(ticket => $"{nameof(ticket.Title)} can't be empty.")
            .MaximumLength(50)
            .WithMessage(ticket => $"{nameof(ticket.Title)} should be less than 50 characters.");

        RuleFor(ticket => ticket.Type)
            .Must(type => types.Contains(type!))
            .WithMessage(ticket =>
                $"{nameof(ticket.Type)} should be one of: {string.Join(", ", types)}");

        RuleFor(ticket => ticket.Description)
            .NotEmpty()
            .WithMessage(ticket => $"{nameof(ticket.Description)} can't be empty.");

        RuleFor(ticket => ticket.Status)
            .Must(status => statuses.Contains(status))
            .WithMessage(ticket =>
                $"{nameof(ticket.Status)} should be one of: {string.Join(", ", statuses)}");

        RuleFor(ticket => ticket.Priority)
            .Must(priority => priorities.Contains(priority))
            .WithMessage(ticket =>
                $"{nameof(ticket.Priority)} should be one of: {string.Join(", ", priorities)}");

        RuleFor(ticket => ticket.Deadline)
            .GreaterThan(DateTime.Now)
            .WithMessage(ticket => $"{nameof(ticket.Deadline)} should be later than now.");
    }
}
