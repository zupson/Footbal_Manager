using AutoMapper;
using ClassLibrary.Dtos;
using ClassLibrary.Models;

namespace ClassLibrary.AutoMapper
{
    public class MatchMappingProfile : Profile
    {
        public MatchMappingProfile()
        {
            CreateMap<MatchDto, Match>();
        }
        
    }
}
