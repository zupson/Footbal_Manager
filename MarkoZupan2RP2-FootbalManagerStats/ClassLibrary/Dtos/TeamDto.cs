using Newtonsoft.Json;

namespace ClassLibrary.Dtos
{
    public class TeamDto
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("code")]
        public string FifaCode { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("penalties")]
        public int Penalties { get; set; }
    }
}
