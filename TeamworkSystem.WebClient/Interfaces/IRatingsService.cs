using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Interfaces
{
    public interface IRatingsService
    {
        Task<IEnumerable<RatingViewModel>> GetByRatedUserId(string userId);

        Task<RatingViewModel> GetByIdAsync(int id);

        Task CreateAsync(RatingViewModel viewModel);

        Task UpdateAsync(RatingViewModel viewModel);

        Task DeleteAsync(int id);
    }
}
