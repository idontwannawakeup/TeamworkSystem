using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;

namespace TeamworkSystem.BusinessLogicLayer.Validation.Requests
{
    public class UserSignInRequestValidator : AbstractValidator<UserSignInRequest>
    {
        public UserSignInRequestValidator()
        {
            RuleFor(request => request.UserName)
                .NotEmpty().WithMessage("Логин пользователя не может быть пустым.");

            RuleFor(request => request.Password)
                .NotEmpty().WithMessage("Пароль пользователя не может быть пустым.");
        }
    }
}
