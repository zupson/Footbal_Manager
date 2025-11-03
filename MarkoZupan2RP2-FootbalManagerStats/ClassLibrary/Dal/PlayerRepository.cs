using AutoMapper;
using ClassLibrary.Constants;
using ClassLibrary.Dtos;
using ClassLibrary.Models;
using ClassLibrary.Utilities;
using Newtonsoft.Json;

namespace ClassLibrary.Dal
{
    public class PlayerRepository : IDataRepository<Player>, ISingleEntityFileLoaderSaver<Player>
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        public PlayerRepository(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }
        public async Task<List<Player>> GetAllFromApi(Gender gender, string? fifaCode = null)
        {
            if (string.IsNullOrEmpty(fifaCode))
                throw new ArgumentException("Fifa codies required for fetching all players");

            string url = GenderUtility.GetGenderMatches(gender, fifaCode);
            try
            {
                string jsonResponse = await _httpClient.GetStringAsync(url);
                var apiResponse = JsonConvert.DeserializeObject<List<MatchDto>>(jsonResponse);
                if (apiResponse == null)
                    return new List<Player>();

                var allPlayers = new List<Player>();
                foreach (var match in apiResponse)
                {
                    if (match.HomeTeamStatistics?.StartingEleven != null)
                        allPlayers.AddRange(_mapper.Map<List<Player>>(match.HomeTeamStatistics.StartingEleven));

                    if (match.HomeTeamStatistics?.Substitutes != null)
                        allPlayers.AddRange(_mapper.Map<List<Player>>(match.HomeTeamStatistics.Substitutes));
                    break;
                }

                return allPlayers
                    .GroupBy(p => new { p.Name, p.ShirtNumber })
                    .Select(g => g.First())
                    .ToList();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error while fetching data: {ex.Message}");
                return new List<Player>();
            }
        }

        public async Task<List<Player>> LoadEntityListFromFile(string filePath, Gender gender, string? fifaCode = null)
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LocalPaths.ParentFolder, LocalPaths.PlayersDir);
            string path = Path.Combine(dir, filePath);

            if (!File.Exists(path))
                return new List<Player>();

            Console.WriteLine(path);
            string json = await File.ReadAllTextAsync(path);//tu puca
            
            var allPlayers = JsonConvert.DeserializeObject<List<Player>>(json);// Deserializacija sadržaja u listu objekata tipa Result
            return allPlayers ?? new List<Player>();
        }

        public async Task SaveEntityListToFile(List<Player> players, string filePath)
        {
            if (players == null)
                throw new ArgumentNullException(nameof(players), "Data to save cannot be null.");

            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LocalPaths.ParentFolder, LocalPaths.PlayersDir);
            
            Directory.CreateDirectory(dir);

            string path = Path.Combine(dir, filePath);

            string json = JsonConvert.SerializeObject(players, Formatting.Indented);
            await File.WriteAllTextAsync(path, json);
        }

        public async Task SaveToFile(Player player, string filePath)
        {
            //if (player == null)
            //    throw new ArgumentNullException(nameof(player), "Data to save cannot be null.");

            //string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            //                                            LocalPaths.ParentFolder,
            //                                            LocalPaths.PlayersDir);
            //Directory.CreateDirectory(dir);

            //string path = Path.Combine(dir, filePath);
            //string json = JsonConvert.SerializeObject(player, Formatting.Indented);

            //await File.WriteAllTextAsync(path, json);
            throw new NotImplementedException();
        }

        public async Task<Player> LoadFromFile(string filePath)
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                                        LocalPaths.ParentFolder,
                                                        LocalPaths.PlayersDir);
            string filepath = Path.Combine(dir, filePath);
            if (!File.Exists(filepath))
                return new Player();

            string json = await File.ReadAllTextAsync(filepath);


            var player = JsonConvert.DeserializeObject<Player>(json);
            return player ?? new Player();
        }
    }
}
