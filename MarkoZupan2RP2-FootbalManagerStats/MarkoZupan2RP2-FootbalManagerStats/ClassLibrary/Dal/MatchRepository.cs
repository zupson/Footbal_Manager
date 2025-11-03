using AutoMapper;
using ClassLibrary.Constants;
using ClassLibrary.Dtos;
using ClassLibrary.Models;
using ClassLibrary.Utilities;
using Newtonsoft.Json;

namespace ClassLibrary.Dal
{
    public class MatchRepository : IDataRepository<Match>
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        public MatchRepository(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<List<Match>> GetAllFromApi(Gender gender, string? fifaCode = null)
        {
            string url = GenderUtility.GetGenderMatches(gender, fifaCode);
            try
            {
                string jsonResponse = await _httpClient.GetStringAsync(url);
                var apiResponse = JsonConvert.DeserializeObject<List<MatchDto>>(jsonResponse);

                if (apiResponse == null)
                    return new List<Match>();

                var matches = _mapper.Map<List<Match>>(apiResponse);
                return matches;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error while fetching data: {ex.Message}");
                return new List<Match>();
            }
        }

        public async Task<List<Match>> LoadEntityListFromFile(string filePath, Gender gender, string? fifaCode = null)
        {

            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LocalPaths.ParentFolder, LocalPaths.MatchesDir);
            string path = Path.Combine(dir, filePath);//LocalPaths.MatchFile
            if (!File.Exists(path))
                return new List<Match>();

            string json = await File.ReadAllTextAsync(path);
            var matches = JsonConvert.DeserializeObject<List<Match>>(json);// Deserializacija sadržaja u listu objekata tipa Result

            return matches ?? new List<Match>();
        }

        public async Task SaveEntityListToFile(List<Match> matches, string filePath)
        {
            if (matches == null)
                throw new ArgumentNullException(nameof(matches), "Data to save cannot be null.");

            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LocalPaths.ParentFolder, LocalPaths.MatchesDir);
            Directory.CreateDirectory(dir);

            string path = Path.Combine(dir, filePath); /*LocalPaths.MatchFile*/

            string json = JsonConvert.SerializeObject(matches, Formatting.Indented);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
