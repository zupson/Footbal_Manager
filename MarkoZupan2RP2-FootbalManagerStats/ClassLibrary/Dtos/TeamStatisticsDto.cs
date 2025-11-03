using Newtonsoft.Json;

namespace ClassLibrary.Dtos
{
    public class TeamStatisitcsApiResponseDto
    {
        [JsonProperty("teams")]
        public List<TeamStatisticsDto> TeamStatisitics { get; set; }
    }

    public class TeamStatisticsDto  //3. node api-a
    {
        [JsonProperty("attempts_on_goal")]
        public int? AttemptsOnGoal { get; set; }

        [JsonProperty("corners")]
        public int? Corners { get; set; }

        [JsonProperty("offsides")]
        public int? Offsides { get; set; }

        [JsonProperty("yellow_cards")]
        public int? YellowCards { get; set; }

        [JsonProperty("red_cards")]
        public int? RedCards { get; set; }

        [JsonProperty("starting_eleven")]
        public List<PlayerDto> StartingEleven { get; set; }

        [JsonProperty("substitutes")]
        public List<PlayerDto> Substitutes { get; set; }
    }
}
