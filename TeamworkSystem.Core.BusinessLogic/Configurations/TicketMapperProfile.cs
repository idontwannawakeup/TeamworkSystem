using AutoMapper;
using TeamworkSystem.Core.BusinessLogic.DTO.Requests;
using TeamworkSystem.Core.BusinessLogic.DTO.Responses;
using TeamworkSystem.Core.DataAccess.Entities;

namespace TeamworkSystem.Core.BusinessLogic.Configurations;

public class TicketMapperProfile : Profile
{
    public TicketMapperProfile()
    {
        CreateMap<TicketRequest, Ticket>();
        CreateMap<Ticket, TicketResponse>();
    }
}
