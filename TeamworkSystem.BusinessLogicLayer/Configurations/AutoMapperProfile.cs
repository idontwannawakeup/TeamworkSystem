using AutoMapper;
using TeamworkSystem.BusinessLogicLayer.DTO.Requests;
using TeamworkSystem.BusinessLogicLayer.DTO.Responses;
using TeamworkSystem.DataAccessLayer.Entities;
using TeamworkSystem.DataAccessLayer.Pagination;

namespace TeamworkSystem.BusinessLogicLayer.Configurations
{
    public class AutoMapperProfile : Profile
    {
        private void CreateUserMaps()
        {
            this.CreateMap<User, UserProfileResponse>();
            this.CreateMap<UserSignUpRequest, User>();
        }

        private void CreateTicketsMaps()
        {
            this.CreateMap<TicketRequest, Ticket>();
            this.CreateMap<Ticket, TicketProfileResponse>();
        }

        private void CreateTeamsMaps()
        {
            this.CreateMap<TeamRequest, Team>();
            this.CreateMap<Team, TeamProfileResponse>();
            this.CreatePageMap<TeamProfileResponse>();
        }

        private void CreateProjectsMaps()
        {
            this.CreateMap<ProjectRequest, Project>();
            this.CreateMap<Project, ProjectProfileResponse>();
        }

        private void CreateRatingsMaps()
        {
            this.CreateMap<RatingRequest, Rating>();
            this.CreateMap<Rating, RatingProfileResponse>();
        }

        private void CreatePageMap<T>()
        {
            this.CreateMap<PagedList<T>, PagedResponse<T>>()
                .ForMember(response => response.Data, opt => opt.MapFrom(pagedList => pagedList));
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
