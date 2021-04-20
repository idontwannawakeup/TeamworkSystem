using FluentValidation;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;

namespace TeamworkSystem.BusinessLogicLayer.Validation.Requests
{
    public class TeamRequestValidator : AbstractValidator<TeamRequest>
    {
        public TeamRequestValidator()
        {
        }
    }
}
