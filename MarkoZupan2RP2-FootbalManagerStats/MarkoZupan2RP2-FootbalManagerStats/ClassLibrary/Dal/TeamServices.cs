using AutoMapper;
using ClassLibrary.AutoMapper;
using ClassLibrary.Constants;
using ClassLibrary.Models;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.Dal
{
    //SINGLETON!
    public class TeamServices
    {
        private static readonly TeamServices _instance = new TeamServices();
        public static TeamServices Instance => _instance;
        private readonly TeamRepository _teamRepo;
        private readonly IMapper _mapper;
        private Team team;
        public TeamServices()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MatchMappingProfile>();
                cfg.AddProfile<PlayerMappingProfile>();
                cfg.AddProfile<TeamMappingProfile>();
                cfg.AddProfile<TeamStatisticsMappingProfile>();
            }, new LoggerFactory());
            _mapper = new Mapper(config);
            _teamRepo = new TeamRepository(new HttpClient(), _mapper);
            //team = new Team();//PROVJERI JE LI OVA INSTANCA POTREBNA
        }

        private string GetFileName(Gender gender)
        {
            string fileName = gender == Gender.Female ? LocalPaths.FemaleFavTeamFile : LocalPaths.MaleFavTeamFile;
            return fileName;
        }
        public async Task<Team> Load(Gender gender)
        {
            string fileName = GetFileName(gender);
            return await _teamRepo.LoadFromFile(fileName);
        }
        public async Task Save(Team favTeam, Gender gender)
        {
            string fileName = GetFileName(gender);
            await _teamRepo.SaveToFile(favTeam, fileName);
        }

        public async Task<List<Team>> GetTeams(Gender gender)
        {
            return await _teamRepo.GetAllFromApi(gender);
        }

        public async Task<List<Team>> GetRivalTeams(Gender gender,Team team)
        {
            return await _teamRepo.GetAllRivalTeamsFromApi(gender, team);
        }
    }
}
