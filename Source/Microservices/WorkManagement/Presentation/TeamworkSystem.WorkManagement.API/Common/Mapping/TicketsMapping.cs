using AutoMapper;
using TeamworkSystem.WorkManagement.API.Grpc.Definitions;
using TeamworkSystem.WorkManagement.Domain.Entities;

namespace TeamworkSystem.WorkManagement.API.Common.Mapping;

public class TicketsMapping : Profile
{
    public TicketsMapping()
    {
        CreateMap<Ticket, GetRecentTicketResponse>()
            .ForMember(
                response => response.Id,
                options => options.MapFrom(t => t.Id.ToString()))
            .ForMember(
                response => response.ProjectId,
                options => options.MapFrom(t => t.ProjectId.ToString()))
            .ForMember(
                response => response.ExecutorId,
                options => options.MapFrom(t => t.ExecutorId.ToString()));
    }
}
