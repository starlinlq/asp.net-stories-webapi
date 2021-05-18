using AutoMapper;
using asp.net.Models;
using asp.net.Dtos.Character;

namespace asp.net
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
        
    }
}