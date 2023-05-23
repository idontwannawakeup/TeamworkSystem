using FluentValidation;
using TeamworkSystem.WorkManagement.Application.Features.Projects.Commands.DeleteProject;

namespace TeamworkSystem.WorkManagement.Application.Common.Validation.Commands;

public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectCommandValidator()
    {
        RuleFor(project => project.Id)
            .NotEmpty()
            .WithMessage(project => $"{nameof(project.Id)} can't be empty.");
    }
}
