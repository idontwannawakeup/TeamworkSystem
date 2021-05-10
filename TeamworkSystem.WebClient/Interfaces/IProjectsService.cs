using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Interfaces
{
    public interface IProjectsService
    {
        Task<IEnumerable<ProjectViewModel>> GetByTeamIdAsync(int teamId);
    }
}
