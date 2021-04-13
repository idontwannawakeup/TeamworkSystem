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
            IEnumerable<Rating> ratings = await this.ratingsRepository.GetAsync();
            return ratings?.Select(this.mapper.Map<Rating, RatingResponse>);
        }

        public async Task<PagedList<RatingResponse>> GetAsync(RatingsParameters parameters)
        {
            PagedList<Rating> ratings = await this.ratingsRepository.GetAsync(parameters);
            return ratings?.Map(this.mapper.Map<Rating, RatingResponse>);
        }

        public async Task<IEnumerable<RatingResponse>> GetRatingProfilesFromUserAsync(string userId)
        {
            IEnumerable<Rating> ratings = await this.ratingsRepository.GetRatingsFromUserAsync(userId);
            return ratings?.Select(this.mapper.Map<Rating, RatingResponse>);
        }

        public async Task<IEnumerable<RatingResponse>> GetRatingProfilesForUserAsync(string userId)
        {
            IEnumerable<Rating> ratings = await this.ratingsRepository.GetRatingsForUserAsync(userId);
            return ratings?.Select(this.mapper.Map<Rating, RatingResponse>);
        }

        public async Task<RatingResponse> GetByIdAsync(int id)
        {
            Rating rating = await this.ratingsRepository.GetByIdAsync(id);
            return this.mapper.Map<Rating, RatingResponse>(rating);
        }

        public async Task InsertAsync(RatingRequest request)
        {
            Rating rating = this.mapper.Map<RatingRequest, Rating>(request);
            await this.ratingsRepository.InsertAsync(rating);
            await this.unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await this.ratingsRepository.DeleteAsync(id);
            await this.unitOfWork.SaveChangesAsync();
        }

        public RatingsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.ratingsRepository = this.unitOfWork.RatingsRepository;
        }
    }
}
