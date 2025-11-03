using AutoMapper;
using ClassLibrary.Dtos;
using ClassLibrary.Models;

namespace ClassLibrary.AutoMapper
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            CreateMap<TeamDto, Team>();

            CreateMap<ResultDto, Team>()
                .ForMember(dest => dest.Country, 
                    opt => opt.MapFrom(src => src.Country))  // Mapira Country
                .ForMember(dest => dest.FifaCode, 
                    opt => opt.MapFrom(src => src.FifaCode))  // Mapira FifaCode 
                .ForMember(dest => dest.Goals, 
                    opt => opt.Ignore())        
                .ForMember(dest => dest.Penalties, 
                    opt => opt.Ignore());
        }
    }
}
