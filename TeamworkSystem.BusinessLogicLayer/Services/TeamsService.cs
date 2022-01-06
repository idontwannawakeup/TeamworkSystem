using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Extensions;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.BusinessLogicLayer.Services;

public class TeamsService : ITeamsService
{
    private readonly IMapper _mapper;
    private readonly IPhotosService _photosService;
    private readonly ITeamsRepository _teamsRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<User> _userManager;

    public TeamsService(IUnitOfWork unitOfWork, IMapper mapper, IPhotosService photosService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _photosService = photosService;
        _teamsRepository = _unitOfWork.TeamsRepository;
        _userManager = _unitOfWork.UserManager;
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

    public async Task<IEnumerable<TeamResponse>> GetUserTeamsAsync(string userId)
    {
        var user = await _userManager.GetByIdAsync(userId);
        var teams = await _teamsRepository.GetUserTeams(user);
        return teams.Select(_mapper.Map<Team, TeamResponse>);
    }

    public async Task<TeamResponse> GetByIdAsync(int id)
    {
        var team = await _teamsRepository.GetByIdAsync(id);
        return _mapper.Map<Team, TeamResponse>(team);
    }

    public async Task InsertAsync(TeamRequest request)
    {
        var team = _mapper.Map<TeamRequest, Team>(request);
        var leader = await _userManager.GetByIdAsync(team.LeaderId!);
        team.Members = new List<User> { leader };
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

    public async Task DeleteAsync(int id)
    {
        await _teamsRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddMemberAsync(TeamMemberRequest request)
    {
        var member = await _userManager.GetByIdAsync(request.UserId);
        await _teamsRepository.AddMemberAsync(request.TeamId, member);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteMemberAsync(TeamMemberRequest request)
    {
        var member = await _userManager.GetByIdAsync(request.UserId);
        await _teamsRepository.DeleteMemberAsync(request.TeamId, member);
        await _unitOfWork.SaveChangesAsync();
    }
}
