namespace ClassLibrary.Constants
{
    public class ApiPaths
    {
        public const string MenFootballWorldCupResult = "https://worldcup-vua.nullbit.hr/men/teams/results";
        public const string WomenFootballWorldCupResult = "https://worldcup-vua.nullbit.hr/women/teams/results";

        public const string MenFootballWorldCupMatches = "https://worldcup-vua.nullbit.hr/men/matches";
        public const string WomenFootballWorldCupMatches = "https://worldcup-vua.nullbit.hr/women/matches";

        public const string MenFootballWorldCupMatchesDetails = "https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code=";
        public const string WomenFootballWorldCupMatchesDetails = "https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code=";
    }

    public class LocalPaths
    {
        public const string ParentFolder = "Data";

        //dir za spremanje teksturlnih JSON fileova
        public const string TeamsDir = "Teams";

        public const string PlayersDir = "Players";
        public const string MatchesDir = "Matchs";
        public const string InitalSettingsDir = "InitialSettings";
        public const string TeamsStaisticsDir = "TeamStatisitcs";
        public const string ImagesDir = "Images";


        //tekstualni fileovi formatirani kako JSON
        public const string FemaleFavTeamFile = "femaleFavTeam.json";
        public const string MaleFavTeamFile = "maleFavTeam.json";

        public const string FemaleFavPlayerFile = "femaleFavPlayers.json";
        public const string MaleFavPlayerFile = "maleFavPlayers.json";

        public const string MatchFile = "match.json";
        public const string InitialSettingsFile = "initialSettings.json";
        public const string TeamStatisticsFile = "teamStatistics.json";

        public const string FemaleAllPlayersFile = "femaleAllPlayers.json";
        public const string FemaleFavPlayersFile = "femaleFavPlayers.json";

        public const string MaleAllPlayersFile = "maleAllPlayers.json";
        public const string MaleFavPlayersFile = "maleFavPlayers.json";
    }
}
