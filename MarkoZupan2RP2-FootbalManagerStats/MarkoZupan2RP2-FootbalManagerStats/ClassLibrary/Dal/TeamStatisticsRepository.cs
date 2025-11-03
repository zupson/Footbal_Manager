using AutoMapper;
using ClassLibrary.Constants;
using ClassLibrary.Dtos;
using ClassLibrary.Models;
using ClassLibrary.Utilities;
using Newtonsoft.Json;

namespace ClassLibrary.Dal
{
    public class TeamStatisticsRepository : IDataRepository<TeamStatistics>
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        public TeamStatisticsRepository(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<List<TeamStatistics>> GetAllFromApi(Gender gender, string? fifaCode = null)
        {
            string url = GenderUtility.GetGenderResult(gender);
            try
            {
                var jsonResponse = await _httpClient.GetStringAsync(url);//JSON string sa API
                var apiResponse = JsonConvert.DeserializeObject<TeamStatisitcsApiResponseDto>(jsonResponse); //Deserijalizacija u DTO objekt
                if (apiResponse?.TeamStatisitics == null)
                    return new List<TeamStatistics>();

                var teamsStatistics = _mapper.Map<List<TeamStatistics>>(apiResponse.TeamStatisitics);
                return teamsStatistics;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error while fetching data: {ex.Message}");
                return new List<TeamStatistics>();
            }
        }

        public async Task<List<TeamStatistics>> LoadEntityListFromFile(string filePath, Gender gender, string? fifaCode = null)
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LocalPaths.ParentFolder, LocalPaths.TeamsStaisticsDir);//definiranje putanje do Foldera za sparemanje fileova
            string path = Path.Combine(dir, filePath); /*LocalPaths.TeamStatisticsFile*/

            if (!File.Exists(path))
                return new List<TeamStatistics>();

            string json = await File.ReadAllTextAsync(path);
            var teamsStatistics = JsonConvert.DeserializeObject<List<TeamStatistics>>(json);// Deserializacija sadržaja u listu objekata tipa Result
            return teamsStatistics ?? new List<TeamStatistics>();
        }

        public async Task SaveEntityListToFile(List<TeamStatistics> teamsStatistics, string filePath)
        {
            if (teamsStatistics == null)
                throw new ArgumentNullException(nameof(teamsStatistics), "Data to save cannot be null.");

            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LocalPaths.ParentFolder, LocalPaths.TeamsStaisticsDir);
            Directory.CreateDirectory(dir);

            string path = Path.Combine(dir, filePath); /*LocalPaths.TeamStatisticsFile*/
            string json = JsonConvert.SerializeObject(teamsStatistics, Formatting.Indented);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
