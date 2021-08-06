using AutoMapper;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.BusinessLogicLayer.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateUserMaps();
            CreateTicketsMaps();
            CreateTeamsMaps();
            CreateProjectsMaps();
            CreateRatingsMaps();
        }

        private void CreateUserMaps()
        {
            CreateMap<UserSignUpRequest, User>();
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>()
                .ForMember(response => response.FullName,
                           options => options.MapFrom(user => $"{user.FirstName} {user.LastName}"))
                .ForMember(response => response.Avatar,
                           options => options.MapFrom(
                               user => !string.IsNullOrWhiteSpace(user.Avatar)
                                   ? $"Public/Photos/{user.Avatar}"
                                   : null));
        }

        private void CreateTicketsMaps()
        {
            CreateMap<TicketRequest, Ticket>();
            CreateMap<Ticket, TicketResponse>();
        }

        private void CreateTeamsMaps()
        {
            CreateMap<TeamRequest, Team>();
            CreateMap<Team, TeamResponse>()
                .ForMember(response => response.Avatar,
                           options => options.MapFrom(
                               team => !string.IsNullOrWhiteSpace(team.Avatar)
                                   ? $"Public/Photos/{team.Avatar}"
                                   : null));
        }

        private void CreateProjectsMaps()
        {
            CreateMap<ProjectRequest, Project>();
            CreateMap<Project, ProjectResponse>();
        }

        private void CreateRatingsMaps()
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
}
