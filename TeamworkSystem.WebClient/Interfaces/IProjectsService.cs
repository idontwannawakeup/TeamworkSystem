﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.Parameters;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Interfaces
{
    public interface IProjectsService
    {
        Task<IEnumerable<ProjectViewModel>> GetAsync(ProjectsParameters parameters);

        Task<(IEnumerable<ProjectViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
            ProjectsParameters parameters);

        Task<IEnumerable<ProjectViewModel>> GetByTeamIdAsync(int teamId);

        Task<IEnumerable<ProjectViewModel>> GetProjectsForTeamMemberAsync(string teamMemberId);

        Task<ProjectViewModel> GetByIdAsync(int id);

        Task CreateAsync(ProjectViewModel viewModel);

        Task UpdateAsync(ProjectViewModel viewModel);

        Task DeleteAsync(int id);
    }
}
