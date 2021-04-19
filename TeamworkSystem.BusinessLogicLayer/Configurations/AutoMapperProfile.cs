using AutoMapper;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.BusinessLogicLayer.Configurations
{
    public class AutoMapperProfile : Profile
    {
        private void CreateUserMaps()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserSignUpRequest, User>();
        }

        private void CreateTicketsMaps()
        {
            CreateMap<TicketRequest, Ticket>();
            CreateMap<Ticket, TicketResponse>();
        }

        private void CreateTeamsMaps()
        {
            CreateMap<TeamRequest, Team>();
            CreateMap<Team, TeamResponse>();
        }

        private void CreateProjectsMaps()
        {
            CreateMap<ProjectRequest, Project>();
            CreateMap<Project, ProjectResponse>();
        }

        private void CreateRatingsMaps()
        {
            CreateMap<RatingRequest, Rating>();
            CreateMap<Rating, RatingResponse>();
        }

        public AutoMapperProfile()
        {
            CreateUserMaps();
            CreateTicketsMaps();
            CreateTeamsMaps();
            CreateProjectsMaps();
            CreateRatingsMaps();
        }
    }
}
