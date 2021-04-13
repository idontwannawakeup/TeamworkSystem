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

        public async Task<IEnumerable<ProjectResponse>> GetAsync()
        {
            IEnumerable<Project> projects = await this.projectsRepository.GetAsync();
            return projects?.Select(this.mapper.Map<Project, ProjectResponse>);
        }

        public async Task<PagedList<ProjectResponse>> GetAsync(ProjectsParameters parameters)
        {
            PagedList<Project> projects = await this.projectsRepository.GetAsync(parameters);
            return projects?.Map(this.mapper.Map<Project, ProjectResponse>);
        }

        public async Task<IEnumerable<ProjectResponse>> GetTeamProjectsAsync(int teamId)
        {
            Team team = await this.unitOfWork.TeamsRepository.GetCompleteEntityAsync(teamId);
            IEnumerable<Project> projects = team?.Projects;
            return projects?.Select(this.mapper.Map<Project, ProjectResponse>);
        }

        public async Task<ProjectResponse> GetByIdAsync(int id)
        {
            Project project = await this.projectsRepository.GetByIdAsync(id);
            return this.mapper.Map<Project, ProjectResponse>(project);
        }

        public async Task InsertAsync(ProjectRequest request)
        {
            Project project = this.mapper.Map<ProjectRequest, Project>(request);
            await this.projectsRepository.InsertAsync(project);
            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await this.projectsRepository.DeleteAsync(id);
            await this.unitOfWork.SaveChangesAsync();
        }

        public ProjectsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.projectsRepository = this.unitOfWork.ProjectsRepository;
        }
    }
}
