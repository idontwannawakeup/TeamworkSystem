using AutoMapper;
using TeamworkSystem.WorkManagement.BusinessLogic.DTO.Requests;
using TeamworkSystem.WorkManagement.BusinessLogic.DTO.Responses;
using TeamworkSystem.WorkManagement.DataAccess.Entities;

namespace TeamworkSystem.WorkManagement.BusinessLogic.Configurations;

public class TicketMapperProfile : Profile
{
    public TicketMapperProfile()
    {
        CreateMap<TicketRequest, Ticket>();
        CreateMap<Ticket, TicketResponse>();
    }
}
