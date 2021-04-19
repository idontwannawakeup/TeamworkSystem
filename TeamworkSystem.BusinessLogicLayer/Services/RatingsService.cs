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
    public class RatingsService : IRatingsService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IRatingsRepository ratingsRepository;

        public async Task<IEnumerable<RatingResponse>> GetAsync()
        {
            var ratings = await ratingsRepository.GetAsync();
            return ratings?.Select(mapper.Map<Rating, RatingResponse>);
        }

        public async Task<PagedList<RatingResponse>> GetAsync(
            RatingsParameters parameters)
        {
            var ratings = await ratingsRepository.GetAsync(parameters);
            return ratings?.Map(mapper.Map<Rating, RatingResponse>);
        }

        public async Task<IEnumerable<RatingResponse>> GetRatingProfilesFromUserAsync(string userId)
        {
            var ratings = await ratingsRepository.GetRatingsFromUserAsync(userId);
            return ratings?.Select(mapper.Map<Rating, RatingResponse>);
        }

        public async Task<IEnumerable<RatingResponse>> GetRatingProfilesForUserAsync(string userId)
        {
            var ratings = await ratingsRepository.GetRatingsForUserAsync(userId);
            return ratings?.Select(mapper.Map<Rating, RatingResponse>);
        }

        public async Task<RatingResponse> GetByIdAsync(int id)
        {
            var rating = await ratingsRepository.GetByIdAsync(id);
            return mapper.Map<Rating, RatingResponse>(rating);
        }

        public async Task InsertAsync(RatingRequest request)
        {
            var rating = mapper.Map<RatingRequest, Rating>(request);
            await ratingsRepository.InsertAsync(rating);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await ratingsRepository.DeleteAsync(id);
            await unitOfWork.SaveChangesAsync();
        }

        public RatingsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            ratingsRepository = this.unitOfWork.RatingsRepository;
        }
    }
}
