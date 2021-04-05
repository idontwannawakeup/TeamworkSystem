using System;
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
    public class RatingsService : IRatingsService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly IRatingsRepository ratingsRepository;

        public async Task<IEnumerable<RatingProfileResponse>> GetAllProfilesAsync()
        {
            IEnumerable<Rating> ratings = await this.ratingsRepository.GetAllAsync();
            return ratings.Select(this.mapper.Map<Rating, RatingProfileResponse>);
        }

        public async Task<IEnumerable<RatingProfileResponse>> GetRatingProfilesFromUserAsync(string userId)
        {
            return await this.GetProfilesByPredicateAsync(rating => rating.FromId == userId);
        }

        public async Task<IEnumerable<RatingProfileResponse>> GetRatingProfilesForUserAsync(string userId)
        {
            return await this.GetProfilesByPredicateAsync(rating => rating.ToId == userId);
        }

        public async Task<RatingProfileResponse> GetProfileByIdAsync(int id)
        {
            Rating rating = await this.ratingsRepository.GetByIdAsync(id);
            return this.mapper.Map<Rating, RatingProfileResponse>(rating);
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

        private async Task<IEnumerable<RatingProfileResponse>> GetProfilesByPredicateAsync(
            Func<Rating, bool> predicate)
        {
            IEnumerable<Rating> ratings = await this.ratingsRepository.GetAllAsync();
            return ratings
                .Where(rating => predicate(rating))
                .Select(this.mapper.Map<Rating, RatingProfileResponse>);
        }

        public RatingsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.ratingsRepository = this.unitOfWork.RatingsRepository;
        }
    }
}
