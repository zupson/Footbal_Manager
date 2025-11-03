using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ClassLibrary.Dtos
{

    public class MatchDto   //2. node api-a
    {
        [JsonProperty("venue")]
        public string Venue { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("attendance")]
        public int Attendance { get; set; }

        [JsonProperty("datetime")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime DateTime { get; set; }
        [JsonProperty("away_team")]
        public TeamDto AwayTeam { get; set; }

        [JsonProperty("home_team")]
        public TeamDto HomeTeam { get; set; }

        [JsonProperty("away_team_statistics")]
        public TeamStatisticsDto AwayTeamStatistics { get; set; }

        [JsonProperty("home_team_statistics")]
        public TeamStatisticsDto HomeTeamStatistics { get; set; }
    }
}
