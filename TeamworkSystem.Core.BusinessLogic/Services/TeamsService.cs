using AutoMapper;
using TeamworkSystem.Core.BusinessLogic.DTO.Requests;
using TeamworkSystem.Core.BusinessLogic.DTO.Responses;
using TeamworkSystem.Core.BusinessLogic.Interfaces.Services;
using TeamworkSystem.Core.DataAccess.Entities;
using TeamworkSystem.Core.DataAccess.Interfaces;
using TeamworkSystem.Core.DataAccess.Interfaces.Repositories;
using TeamworkSystem.Core.DataAccess.Parameters;
using TeamworkSystem.Shared.Pagination;

namespace TeamworkSystem.Core.BusinessLogic.Services;

// TODO: fix logic with adding members and other actions with users
public class TeamsService : ITeamsService
{
    private readonly IMapper _mapper;
    private readonly IPhotosService _photosService;
    private readonly ITeamsRepository _teamsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TeamsService(IUnitOfWork unitOfWork, IMapper mapper, IPhotosService photosService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _photosService = photosService;
        _teamsRepository = _unitOfWork.TeamsRepository;
    }

    public async Task<IEnumerable<TeamResponse>> GetAsync()
    {
        var teams = await _teamsRepository.GetAsync();
        return teams.Select(_mapper.Map<Team, TeamResponse>);
    }

    public async Task<PagedList<TeamResponse>> GetAsync(TeamsParameters parameters)
    {
        var teamsPage = await _teamsRepository.GetAsync(parameters);
        return teamsPage.Map(_mapper.Map<Team, TeamResponse>);
    }

    public async Task<IEnumerable<TeamResponse>> GetUserTeamsAsync(Guid userId)
    {
        var user = new UserProfile { Id = userId };
        var teams = await _teamsRepository.GetUserTeams(user);
        return teams.Select(_mapper.Map<Team, TeamResponse>);
    }

    public async Task<TeamResponse> GetByIdAsync(Guid id)
    {
        var team = await _teamsRepository.GetByIdAsync(id);
        return _mapper.Map<Team, TeamResponse>(team);
    }

    public async Task InsertAsync(TeamRequest request)
    {
        var team = _mapper.Map<TeamRequest, Team>(request);
        var leader = new UserProfile { Id = request.LeaderId };
        team.Members = new List<UserProfile> { leader };
        await _teamsRepository.InsertAsync(team);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(TeamRequest request)
    {
        var team = _mapper.Map<TeamRequest, Team>(request);
        await _teamsRepository.UpdateAsync(team);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task SetAvatarForTeamAsync(TeamAvatarRequest request)
    {
        var team = await _teamsRepository.GetByIdAsync(request.TeamId);
        team.Avatar = await _photosService.SavePhotoAsync(request.Avatar);
        await _teamsRepository.UpdateAsync(team);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await _teamsRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddMemberAsync(TeamMemberRequest request)
    {
        var member = new UserProfile { Id = request.UserId };
        await _teamsRepository.AddMemberAsync(request.TeamId, member);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteMemberAsync(TeamMemberRequest request)
    {
        var member = new UserProfile { Id = request.UserId };
        await _teamsRepository.DeleteMemberAsync(request.TeamId, member);
        await _unitOfWork.SaveChangesAsync();
    }
}
