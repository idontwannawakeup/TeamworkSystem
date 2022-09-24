using AutoMapper;
using TeamworkSystem.WorkManagement.Application.Common.Models.Responses;
using TeamworkSystem.WorkManagement.Application.Features.Tickets.Commands.CreateTicket;
using TeamworkSystem.WorkManagement.Application.Features.Tickets.Commands.UpdateTicket;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.Application.Common.Mapping;

public class TicketMapping : Profile
{
    public TicketMapping()
    {
        CreateMap<CreateTicketCommand, Ticket>();
        CreateMap<UpdateTicketCommand, Ticket>();
        CreateMap<Ticket, TicketResponse>();
    }
}
