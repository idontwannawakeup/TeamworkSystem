using AutoMapper;
using TeamworkSystem.Content.Application.Common.Responses;
using TeamworkSystem.Content.Application.Grpc.Definitions;

namespace TeamworkSystem.Content.Application.Common.Mapping;

public class TicketMapping : Profile
{
    public TicketMapping()
    {
        CreateMap<GetRecentTicketResponse, TicketResponse>()
            .ForMember(
                response => response.Id,
                options => options.MapFrom(t => Guid.Parse(t.Id)))
            .ForMember(
                response => response.ProjectId,
                options => options.MapFrom(t => Guid.Parse(t.ProjectId)))
            .ForMember(
                response => response.ExecutorId,
                options => options.MapFrom(
                    t => !string.IsNullOrWhiteSpace(t.Id) ? Guid.Parse(t.Id) : Guid.Empty));
    }
}
