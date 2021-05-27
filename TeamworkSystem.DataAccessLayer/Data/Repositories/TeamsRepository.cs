﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Exceptions;
using TeamworkSystem.DataAccessLayer.Interfaces.Repositories;
using TeamworkSystem.DataAccessLayer.Pagination;
using TeamworkSystem.DataAccessLayer.Parameters;

namespace TeamworkSystem.DataAccessLayer.Data.Repositories
{
    public class TeamsRepository : GenericRepository<Team>, ITeamsRepository
    {
        public override async Task<Team> GetCompleteEntityAsync(int id)
        {
            var team = await table.Include(team => team.Leader)
                                  .Include(team => team.Projects)
                                  .Include(team => team.Members)
                                  .SingleOrDefaultAsync(team => team.Id == id);

            return team ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<PagedList<Team>> GetAsync(TeamsParameters parameters)
        {
            IQueryable<Team> source = table.Include(team => team.Leader);

            SearchByMemberId(ref source, parameters.UserId);
            SearchByName(ref source, parameters.Name);
            SearchBySpecialization(ref source, parameters.Specialization);

            return await PagedList<Team>.ToPagedListAsync(
                source,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public async Task<IEnumerable<Team>> GetUserTeams(User user)
        {
            return await table.Where(team => team.Members.Contains(user))
                              .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetMembersAsync(int id)
        {
            var team = await table.Include(team => team.Members)
                                  .SingleOrDefaultAsync(team => team.Id == id);

            if (team is null)
            {
                throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
            }

            return team?.Members;
        }

        public async Task AddMemberAsync(int id, User member)
        {
            var team = await table.Include(team => team.Members)
                                  .SingleOrDefaultAsync(team => team.Id == id);

            if (team is null)
            {
                throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
            }

            team?.Members?.Add(member);
        }

        public async Task DeleteMemberAsync(int id, User member)
        {
            var team = await table.Include(team => team.Members)
                                  .SingleOrDefaultAsync(team => team.Id == id);

            if (team is null)
            {
                throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
            }

            team?.Members?.Remove(member);
        }

        private static void SearchByMemberId(ref IQueryable<Team> source, string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return;
            }

            source = source.Where(team => team.Members.Any(user => user.Id == userId));
        }

        private static void SearchByName(ref IQueryable<Team> source, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            source = source.Where(team => team.Name.Contains(name));
        }

        private static void SearchBySpecialization(ref IQueryable<Team> source, string specialization)
        {
            if (string.IsNullOrWhiteSpace(specialization))
            {
                return;
            }

            source = source.Where(team => team.Specialization == specialization);
        }

        public TeamsRepository(TeamworkSystemContext databaseContext)
            : base(databaseContext)
        {
        }
    }
}
