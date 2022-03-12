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

public class ProjectsService : IProjectsService
{
    private readonly IMapper _mapper;
    private readonly IProjectsRepository _projectsRepository;
    private readonly ITeamsRepository _teamsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProjectsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _projectsRepository = _unitOfWork.ProjectsRepository;
        _teamsRepository = _unitOfWork.TeamsRepository;
    }

    public async Task<IEnumerable<ProjectResponse>> GetAsync()
    {
        var projects = await _projectsRepository.GetAsync();
        return projects.Select(_mapper.Map<Project, ProjectResponse>);
    }

    public async Task<PagedList<ProjectResponse>> GetAsync(ProjectsParameters parameters)
    {
        var projects = await _projectsRepository.GetAsync(parameters);
        return projects.Map(_mapper.Map<Project, ProjectResponse>);
    }

    public async Task<IEnumerable<ProjectResponse>> GetTeamProjectsAsync(int teamId)
    {
        var team = await _teamsRepository.GetCompleteEntityAsync(teamId);
        var projects = team.Projects;
        return projects.Select(_mapper.Map<Project, ProjectResponse>);
    }

    public async Task<ProjectResponse> GetByIdAsync(int id)
    {
        var project = await _projectsRepository.GetCompleteEntityAsync(id);
        return _mapper.Map<Project, ProjectResponse>(project);
    }

    public async Task InsertAsync(ProjectRequest request)
    {
        var project = _mapper.Map<ProjectRequest, Project>(request);
        await _projectsRepository.InsertAsync(project);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProjectRequest request)
    {
        var project = _mapper.Map<ProjectRequest, Project>(request);
        await _projectsRepository.UpdateAsync(project);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _projectsRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
