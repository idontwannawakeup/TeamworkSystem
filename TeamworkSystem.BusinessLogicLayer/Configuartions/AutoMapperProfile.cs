using AutoMapper;
using TeamworkSystem.BusinessLogicLayer.DTO;
using TeamworkSystem.DataAccessLayer.Entities;

namespace TeamworkSystem.BusinessLogicLayer.Configuartions
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<User, UserDTO>();
        }
    }
}
