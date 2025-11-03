using AutoMapper;
using ClassLibrary.Dtos;
using ClassLibrary.Models;

namespace ClassLibrary.AutoMapper
{
    public class TeamStatisticsMappingProfile : Profile
    {
        public TeamStatisticsMappingProfile()
        {
            CreateMap<TeamStatisticsDto, TeamStatistics>();
        }
    }
}
