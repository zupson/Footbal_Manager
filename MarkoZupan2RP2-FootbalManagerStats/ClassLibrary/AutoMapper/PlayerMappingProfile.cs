using AutoMapper;
using ClassLibrary.Dtos;
using ClassLibrary.Models;
using ClassLibrary.Utilities;

namespace ClassLibrary.AutoMapper
{
    public class PlayerMappingProfile : Profile
    {
        public PlayerMappingProfile()
        {
            CreateMap<PlayerDto, Player>()
                .ForMember(dest => dest.Name,
                    opt => opt.ConvertUsing(
                            new PlayerFormatterConverter()))
                .ForMember(dest => dest.IsFavourite,
                    opt => opt.Ignore())
                .ForMember(dest => dest.ScoredGoals,
                    opt => opt.Ignore())
                .ForMember(dest => dest.YellowCards,
                    opt => opt.Ignore());
        }
    }
}
