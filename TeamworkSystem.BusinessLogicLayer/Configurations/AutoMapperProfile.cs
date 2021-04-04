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

        public AutoMapperProfile()
        {
            this.CreateUserMaps();
            this.CreateTicketsMaps();
        }
    }
}
