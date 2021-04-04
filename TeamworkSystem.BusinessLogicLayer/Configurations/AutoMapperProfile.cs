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
        }

        public AutoMapperProfile()
        {
            this.CreateUserMaps();
            this.CreateTicketsMaps();
            this.CreateTeamsMaps();
        }
    }
}
