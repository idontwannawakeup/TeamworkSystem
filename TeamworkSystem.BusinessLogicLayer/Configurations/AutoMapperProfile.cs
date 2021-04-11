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
            this.CreateMap<User, UserResponse>();
            this.CreateMap<UserSignUpRequest, User>();
        }

        private void CreateTicketsMaps()
        {
            this.CreateMap<TicketRequest, Ticket>();
            this.CreateMap<Ticket, TicketResponse>();
        }

        private void CreateTeamsMaps()
        {
            this.CreateMap<TeamRequest, Team>();
            this.CreateMap<Team, TeamResponse>();
        }

        private void CreateProjectsMaps()
        {
            this.CreateMap<ProjectRequest, Project>();
            this.CreateMap<Project, ProjectResponse>();
        }

        private void CreateRatingsMaps()
        {
            this.CreateMap<RatingRequest, Rating>();
            this.CreateMap<Rating, RatingResponse>();
        }

        public AutoMapperProfile()
        {
            this.CreateUserMaps();
            this.CreateTicketsMaps();
            this.CreateTeamsMaps();
            this.CreateProjectsMaps();
            this.CreateRatingsMaps();
        }
    }
}
