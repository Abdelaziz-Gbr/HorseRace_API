using AutoMapper;
using HorseRace_API.Models.Domain;
using HorseRace_API.Models.Dto;

namespace HorseRace_API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
