﻿using System;
using FluentValidation;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Validation
{
    public class ProjectViewModelValidator : AbstractValidator<ProjectViewModel>
    {
        public ProjectViewModelValidator()
        {
            RuleFor(project => project.TeamId)
                .NotEmpty()
                .WithMessage(project => $"{nameof(project.TeamId)} can't be empty.");

            RuleFor(project => project.Team)
                .NotEmpty()
                .WithMessage(project => $"{nameof(project.Team)} can't be empty.");

            RuleFor(project => project.Title)
                .NotEmpty()
                .WithMessage(project => $"{nameof(project.Title)} can't be empty.")
                .MaximumLength(50)
                .WithMessage(project => $"{nameof(project.Title)} should be less than 50 characters.");

            RuleFor(project => project.Type)
                .MaximumLength(50)
                .WithMessage(project => $"{nameof(project.Type)} should be less than 50 characters.");

            RuleFor(project => project.Url)
                .MaximumLength(50)
                .WithMessage(project => $"{nameof(project.Url)} should be less than 50 characters.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                .When(project => !string.IsNullOrWhiteSpace(project.Url))
                .WithMessage(project => $"{nameof(project.Url)} has wrong format.");
        }
    }
}
