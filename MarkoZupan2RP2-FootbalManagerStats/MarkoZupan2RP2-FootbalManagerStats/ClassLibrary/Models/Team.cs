
namespace ClassLibrary.Models
{
    public class Team
    {
        public string Country { get; set; }
        public string FifaCode { get; set; }
        public int Goals { get; set; }
        public int Penalties { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Team team &&
                   Country == team.Country &&
                   FifaCode == team.FifaCode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Country, FifaCode);
        }

        public override string ToString() => $"{Country} ({FifaCode})";
    }
}
