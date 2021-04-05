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

namespace TeamworkSystem.BusinessLogicLayer.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IProjectsRepository projectsRepository;

        public async Task<IEnumerable<ProjectProfileResponse>> GetAllProfilesAsync()
        {
            IEnumerable<Project> projects = await this.projectsRepository.GetAllAsync();
            return projects?.Select(this.mapper.Map<Project, ProjectProfileResponse>);
        }

        public async Task<IEnumerable<ProjectProfileResponse>> GetProfilesOfTeamProjectsAsync(int teamId)
        {
            Team team = await this.unitOfWork.TeamsRepository.GetCompleteTeamAsync(teamId);
            IEnumerable<Project> projects = team?.Projects;
            return projects?.Select(this.mapper.Map<Project, ProjectProfileResponse>);
        }

        public async Task<ProjectProfileResponse> GetProfileByIdAsync(int id)
        {
            Project project = await this.projectsRepository.GetByIdAsync(id);
            return this.mapper.Map<Project, ProjectProfileResponse>(project);
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
