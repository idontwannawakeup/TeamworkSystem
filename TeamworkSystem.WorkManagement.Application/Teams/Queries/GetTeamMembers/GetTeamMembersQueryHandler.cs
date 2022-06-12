using MediatR;
using AutoMapper;
using TeamworkSystem.WorkManagement.Application.Common.Responses;
using TeamworkSystem.WorkManagement.Application.Interfaces;

namespace TeamworkSystem.WorkManagement.Application.Teams.Queries.GetTeamMembers;

public class GetTeamMembersQueryHandler : IRequestHandler<GetTeamMembersQuery, IEnumerable<UserResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTeamMembersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponse>> Handle(
        GetTeamMembersQuery request,
        CancellationToken cancellationToken)
    {
        var members = await _unitOfWork.TeamsRepository.GetMembersAsync(request.TeamId);
        return _mapper.Map<IEnumerable<UserResponse>>(members);
    }
}
