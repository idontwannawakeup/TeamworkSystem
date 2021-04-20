using FluentValidation;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;

namespace TeamworkSystem.BusinessLogicLayer.Validation.Requests
{
    public class TicketRequestValidtor : AbstractValidator<TicketRequest>
    {
        public TicketRequestValidtor()
        {
        }
    }
}
