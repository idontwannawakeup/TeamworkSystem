using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.BusinessLogicLayer.Extensions;
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
            var teams = await teamsRepository.GetAsync();
            return teams?.Select(mapper.Map<Team, TeamResponse>);
        }

        public async Task<PagedList<TeamResponse>> GetAsync(
            TeamsParameters parameters)
        {
            var teamsPage = await teamsRepository.GetAsync(parameters);
            return teamsPage?.Map(mapper.Map<Team, TeamResponse>);
        }

        public async Task<IEnumerable<TeamResponse>> GetUserTeamsAsync(string userId)
        {
            var user = await userManager.GetByIdAsync(userId);
            var teams = await teamsRepository.GetUserTeams(user);
            return teams?.Select(mapper.Map<Team, TeamResponse>);
        }

        public async Task<TeamResponse> GetByIdAsync(int id)
        {
            var team = await teamsRepository.GetByIdAsync(id);
            return mapper.Map<Team, TeamResponse>(team);
        }

        public async Task InsertAsync(TeamRequest request)
        {
            var team = mapper.Map<TeamRequest, Team>(request);
            await teamsRepository.InsertAsync(team);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await teamsRepository.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
        }

        public TeamsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            teamsRepository = this.unitOfWork.TeamsRepository;
            userManager = this.unitOfWork.UserManager;
        }
    }
}
