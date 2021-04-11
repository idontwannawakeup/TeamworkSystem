using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Interfaces.Services;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Interfaces;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.BusinessLogicLayer.Services
{
    public class TeamsService : ITeamsService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly ITeamsRepository teamsRepository;

        private readonly UserManager<User> userManager;

        public async Task<IEnumerable<TeamResponse>> GetAsync()
        {
            IEnumerable<Team> teams = await this.teamsRepository.GetAsync();
            return teams?.Select(this.mapper.Map<Team, TeamResponse>);
        }

        public async Task<PagedList<TeamResponse>> GetAsync(TeamsParameters parameters)
        {
            PagedList<Team> teamsPage = await this.teamsRepository.GetAsync(parameters);
            return teamsPage?.Map(this.mapper.Map<Team, TeamResponse>);
        }

        public async Task<IEnumerable<TeamResponse>> GetUserTeamsAsync(string userId)
        {
            User user = await this.userManager.FindByIdAsync(userId)
                ?? throw new EntityNotFoundException($"{nameof(User)} with id {userId} not found.");

            IEnumerable<Team> teams = await this.teamsRepository.GetUserTeams(user);
            return teams?.Select(this.mapper.Map<Team, TeamResponse>);
        }

        public async Task<TeamResponse> GetByIdAsync(int id)
        {
            Team team = await this.teamsRepository.GetByIdAsync(id);
            return this.mapper.Map<Team, TeamResponse>(team);
        }

        public async Task InsertAsync(TeamRequest request)
        {
            Team team = this.mapper.Map<TeamRequest, Team>(request);
            await this.teamsRepository.InsertAsync(team);
            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await this.teamsRepository.DeleteAsync(id);
            await this.unitOfWork.SaveChangesAsync();
        }

        public TeamsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.teamsRepository = this.unitOfWork.TeamsRepository;
            this.userManager = this.unitOfWork.UserManager;
        }
    }
}
