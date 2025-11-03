using Newtonsoft.Json;

namespace ClassLibrary.Dtos
{
    //public class PlayerApiResponseDto   //1. node api-a
    //{
    //    [JsonProperty("matches")]
    //    public List<MatchDto> Matches { get; set; }
    //}

    public class PlayerDto  //4. node api-a
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("captain")]
        public bool IsCaptain { get; set; }

        [JsonProperty("shirt_number")]
        public int ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }
    }
}
