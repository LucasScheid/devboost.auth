using api_dev_boost_auth.Entities.DataTransferObjects;
using api_dev_boost_auth.Entities.Models;
using AutoMapper;

namespace api_dev_boost_auth
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
