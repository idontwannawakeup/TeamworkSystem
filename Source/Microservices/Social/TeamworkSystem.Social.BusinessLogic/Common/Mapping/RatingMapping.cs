using AutoMapper;
using TeamworkSystem.Social.BusinessLogic.Common.Models.Requests;
using TeamworkSystem.Social.BusinessLogic.Common.Models.Responses;
using TeamworkSystem.Social.DataAccess.Data.Entities;

namespace TeamworkSystem.Social.BusinessLogic.Common.Mapping;

public class RatingMapping : Profile
{
    public RatingMapping()
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
