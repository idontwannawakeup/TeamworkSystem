using AutoMapper;
using TeamworkSystem.Social.BusinessLogic.DTO.Requests;
using TeamworkSystem.Social.BusinessLogic.DTO.Responses;
using TeamworkSystem.Social.DataAccess.Entities;

namespace TeamworkSystem.Social.BusinessLogic.Configurations;

public class RatingMapperProfile : Profile
{
    public RatingMapperProfile()
    {
        CreateMap<RatingRequest, Rating>();
        CreateMap<Rating, RatingResponse>()
            .ForMember(response => response.Average,
                options => options.MapFrom(
                    rating => (rating.Skills
                               + rating.Social
                               + rating.Punctuality
                               + rating.Responsibility) / 4));
    }
}
