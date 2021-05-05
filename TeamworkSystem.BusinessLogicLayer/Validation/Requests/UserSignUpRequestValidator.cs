using FluentValidation;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;

namespace TeamworkSystem.BusinessLogicLayer.Validation.Requests
{
    public class UserSignUpRequestValidator : AbstractValidator<UserSignUpRequest>
    {
        public UserSignUpRequestValidator()
        {
            RuleFor(request => request.UserName)
                .NotEmpty().WithMessage("UserName can't be empty.");

            RuleFor(request => request.Password)
                .NotEmpty().WithMessage("Password can't be empty.");
        }
    }
}
