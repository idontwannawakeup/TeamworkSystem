using AutoMapper;
using TeamworkSystem.Shared.Pagination;
using TeamworkSystem.WorkManagement.Application.Common.Requests;
using TeamworkSystem.WorkManagement.Application.Common.Responses;
using TeamworkSystem.WorkManagement.Application.Interfaces;
using TeamworkSystem.WorkManagement.Application.Interfaces.Repositories;
using TeamworkSystem.WorkManagement.Application.Interfaces.Services;
using TeamworkSystem.WorkManagement.Domain.Entities;
using TeamworkSystem.WorkManagement.Domain.Parameters;

namespace TeamworkSystem.WorkManagement.Application.Services;

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

    public async Task<IEnumerable<ProjectResponse>> GetTeamProjectsAsync(Guid teamId)
    {
        var team = await _teamsRepository.GetCompleteEntityAsync(teamId);
        var projects = team.Projects;
        return projects.Select(_mapper.Map<Project, ProjectResponse>);
    }

    public async Task<ProjectResponse> GetByIdAsync(Guid id)
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

    public async Task DeleteAsync(Guid id)
    {
        await _projectsRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
