using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.BusinessLogicLayer.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IProjectsRepository projectsRepository;

        private readonly ITeamsRepository teamsRepository;

        public async Task<IEnumerable<ProjectResponse>> GetAsync()
        {
            var projects = await projectsRepository.GetAsync();
            return projects?.Select(mapper.Map<Project, ProjectResponse>);
        }

        public async Task<PagedList<ProjectResponse>> GetAsync(
            ProjectsParameters parameters)
        {
            var projects = await projectsRepository.GetAsync(parameters);
            return projects?.Map(mapper.Map<Project, ProjectResponse>);
        }

        public async Task<IEnumerable<ProjectResponse>> GetTeamProjectsAsync(int teamId)
        {
            var team = await teamsRepository.GetCompleteEntityAsync(teamId);
            var projects = team?.Projects;
            return projects?.Select(mapper.Map<Project, ProjectResponse>);
        }

        public async Task<ProjectResponse> GetByIdAsync(int id)
        {
            var project = await projectsRepository.GetByIdAsync(id);
            return mapper.Map<Project, ProjectResponse>(project);
        }

        public async Task InsertAsync(ProjectRequest request)
        {
            var project = mapper.Map<ProjectRequest, Project>(request);
            await projectsRepository.InsertAsync(project);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await projectsRepository.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
        }

        public ProjectsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            projectsRepository = this.unitOfWork.ProjectsRepository;
            teamsRepository = this.unitOfWork.TeamsRepository;
        }
    }
}
