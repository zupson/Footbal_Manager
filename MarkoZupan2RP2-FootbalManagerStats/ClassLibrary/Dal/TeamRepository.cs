using AutoMapper;
using ClassLibrary.Dtos;
using ClassLibrary.Models;
using ClassLibrary.Utilities;
using Newtonsoft.Json;

namespace ClassLibrary.Dal
{
    public class TeamRepository : IDataRepository<Team>, ISingleEntityFileLoaderSaver<Team>
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        public TeamRepository(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient; //injekcija http klijnta za pozive prema API
            _mapper = mapper;
        }

        // Dohvat svih timova s API-ja, bez potrebe za fifaCode, za zadani GenderS
        public async Task<List<Team>> GetAllFromApi(Gender gender, string? fifaCode = null)
        {
            string url = GenderUtility.GetGenderResult(gender);
            try
            {
                var jsonResponse = await _httpClient.GetStringAsync(url);//JSON string sa API
                var apiResponse = JsonConvert.DeserializeObject<List<ResultDto>>(jsonResponse);
                if (apiResponse == null)
                    return new List<Team>();

                var teams = _mapper.Map<List<Team>>(apiResponse);
                return teams; // tu vracam samo fifa code i country 
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error while fetching data: {ex.Message}");
                return new List<Team>();
            }
        }

        public async Task<List<Team>> LoadEntityListFromFile(string filePath, Gender gender, string? fifaCode = null)
        {
            //string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LocalPaths.ParentFolder, LocalPaths.TeamsDir);//definiranje putanje do Foldera za sparemanje fileova

            //string path = Path.Combine(dir,filePath ); //LocalPaths.TeamFile

            //if (!File.Exists(path))
            //    return new List<Result>();

            //string json = await File.ReadAllTextAsync(path);
            //var teams = JsonConvert.DeserializeObject<List<Result>>(json);// Deserializacija sadržaja u listu objekata tipa Result
            //return teams ?? new List<Result>();
            throw new NotImplementedException();
        }


        public async Task SaveEntityListToFile(List<Team> teams, string filePath)
        {
            //if (teams == null)
            //    throw new ArgumentNullException(nameof(teams), "Data to save cannot be null.");

            //string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LocalPaths.ParentFolder, LocalPaths.TeamsDir);
            //Directory.CreateDirectory(dir);

            //string filePath = Path.Combine(dir, LocalPaths.TeamFile);

            //// Serijalizacija liste objekata u JSON format, lijepo formatiran (za čitljivost)
            //string json = JsonConvert.SerializeObject(teams, Formatting.Indented);

            //// Asinhrono spremanje JSON stringa u datoteku
            //await File.WriteAllTextAsync(filePath, json);
            throw new NotImplementedException();

        }
        public async Task SaveToFile(Team team, string fileName)
        {
            try
            {
                if (team == null)
                    throw new ArgumentNullException(nameof(team), "Data to save cannot be null.");

                string filePath = FileUtility.GetFilePath(fileName, "FavTeams");
                string json = JsonConvert.SerializeObject(team, Formatting.Indented);

                await File.WriteAllTextAsync(filePath, json);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving team to file: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }
        //public async Task SaveToFile(Team team, string filePath)
        //{
        //    try
        //    {
        //        if (team == null)
        //            throw new ArgumentNullException(nameof(team), "Data to save cannot be null.");
        //        string fileName = "favTeam.json";

        //        string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
        //                                                    LocalPaths.ParentFolder,
        //                                                    LocalPaths.TeamsDir);
        //        Directory.CreateDirectory(dir);

        //        string path = Path.Combine(dir, filePath);
        //        string json = JsonConvert.SerializeObject(team, Formatting.Indented);
        //        await File.WriteAllTextAsync(path, json);
        //        Console.WriteLine($"Team data saved successfully to: {path}");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error saving team to file: {ex.Message}");
        //        Console.WriteLine(ex.StackTrace);
        //    }
        //}

        public async Task<Team> LoadFromFile(string fileName)
        {
            try
            {
                string filePath = FileUtility.GetFilePath(fileName, "FavTeams");

                if (!File.Exists(filePath))
                    return new Team();

                string json = await File.ReadAllTextAsync(filePath);
                var team = JsonConvert.DeserializeObject<Team>(json);

                return team ?? new Team();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading team from file: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                return new Team();
            }
        }
        //public async Task<Team> LoadFromFile(string fileName)
        //{
        //    string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, LocalPaths.ParentFolder, LocalPaths.TeamsDir);
        //    Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

        //    string modifiedDirPath = dir.Replace("WpfApp", "WinFormsApp");

        //    string path = Path.Combine(modifiedDirPath, fileName);

        //    if (!File.Exists(path))
        //        return new Team();

        //    string json = await File.ReadAllTextAsync(path);
        //    var team = JsonConvert.DeserializeObject<Team>(json);

        //    return team ?? new Team();
        //}

        public async Task<List<Team>> GetAllRivalTeamsFromApi(Gender gender, Team team)
        {
            if (string.IsNullOrEmpty(team.FifaCode))
                throw new ArgumentException("Fifa codies required for fetching rival teams");

            string url = GenderUtility.GetGenderMatches(gender, team.FifaCode);

            try
            {
                string jsonResponse = await _httpClient.GetStringAsync(url);
                var apiResponse = JsonConvert.DeserializeObject<List<MatchDto>>(jsonResponse);

                if (apiResponse == null)
                    return new List<Team>();

                var allRivalTeams = new List<Team>();

                foreach (var matchDto in apiResponse)
                {
                    if (matchDto.HomeTeam.FifaCode != null && matchDto.HomeTeam.FifaCode == team.FifaCode)
                        allRivalTeams.Add(_mapper.Map<Team>(matchDto.AwayTeam));

                    else if (matchDto.HomeTeam.FifaCode != null && matchDto.AwayTeam.FifaCode == team.FifaCode)
                        allRivalTeams.Add(_mapper.Map<Team>(matchDto.HomeTeam));
                }

                return allRivalTeams
                    .Distinct()
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching data: {ex.Message}");
                return new List<Team>();
            }
        }
    }
}
