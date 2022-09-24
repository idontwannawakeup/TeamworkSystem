using AutoMapper;
using Grpc.Core;
using TeamworkSystem.WorkManagement.API.Grpc.Definitions;
using TeamworkSystem.WorkManagement.Application.Interfaces;

namespace TeamworkSystem.WorkManagement.API.Grpc;

public class RecentService : RecentRequestsService.RecentRequestsServiceBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RecentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public override async Task<GetRecentProjectsResponse> GetRecentProjects(
        GetRecentProjectsRequest request,
        ServerCallContext context)
    {
        var projects =
            await _unitOfWork.ProjectsRepository.GetAsync(request.Ids.Select(Guid.Parse));
        return new GetRecentProjectsResponse
        {
            Projects = { _mapper.Map<IEnumerable<GetRecentProjectResponse>>(projects) }
        };
    }

    public override async Task<GetRecentTeamsResponse> GetRecentTeams(
        GetRecentTeamsRequest request,
        ServerCallContext context)
    {
        var teams = await _unitOfWork.TeamsRepository.GetAsync(request.Ids.Select(Guid.Parse));
        return new GetRecentTeamsResponse
        {
            Teams = { _mapper.Map<IEnumerable<GetRecentTeamResponse>>(teams) }
        };
    }

    public override async Task<GetRecentTicketsResponse> GetRecentTickets(
        GetRecentTicketsRequest request,
        ServerCallContext context)
    {
        var tickets = await _unitOfWork.TicketsRepository.GetAsync(request.Ids.Select(Guid.Parse));
        return new GetRecentTicketsResponse
        {
            Tickets = { _mapper.Map<IEnumerable<GetRecentTicketResponse>>(tickets) }
        };
    }
}
