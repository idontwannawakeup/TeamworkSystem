using AutoMapper;
using Grpc.Net.Client;
using MediatR;
using TeamworkSystem.Content.Application.Common.Responses;
using TeamworkSystem.Content.Application.Common.Settings;
using TeamworkSystem.Content.Application.Grpc.Definitions;
using TeamworkSystem.Content.Application.Interfaces;
using TeamworkSystem.Content.Domain.Enums;

namespace TeamworkSystem.Content.Application.Recent.Queries.GetRecentProjects;

public class GetRecentProjectsQueryHandler
    : IRequestHandler<GetRecentProjectsQuery, IEnumerable<ProjectResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ServicesSettings _settings;

    public GetRecentProjectsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ServicesSettings settings)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _settings = settings;
    }

    public async Task<IEnumerable<ProjectResponse>> Handle(
        GetRecentProjectsQuery request,
        CancellationToken cancellationToken)
    {
        var recent = await _unitOfWork.RecentRequestRepository.GetAsync(
            request.UserId,
            RecentRequestEntityType.Project);

        var grpcRequest = new GetRecentProjectsRequest
        {
            Ids = { recent.Select(r => r.RequestedEntityId.ToString()) }
        };

        using var channel = GrpcChannel.ForAddress(_settings.WorkManagementUrl);
        var client = new RecentRequestsService.RecentRequestsServiceClient(channel);
        var response = await client.GetRecentProjectsAsync(
            grpcRequest,
            cancellationToken: cancellationToken);

        return _mapper.Map<IEnumerable<ProjectResponse>>(response.Projects);
    }
}
