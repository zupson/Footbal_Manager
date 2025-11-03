using ClassLibrary.Constants;
using ClassLibrary.Models;

namespace ClassLibrary.Utilities
{
    public class GenderUtility
    {
        public static string GetGenderResult(Gender gender)
        {
            return gender switch
            {
                Gender.Male => ApiPaths.MenFootballWorldCupResult,
                Gender.Female => ApiPaths.WomenFootballWorldCupResult,
                _ => throw new ArgumentException("Invalid gender teamsStatistics")
            };
        }

        public static string GetGenderMatches(Gender gender, string? fifaCode = null)
        {
            string urlBasedOnGender = gender switch
            {
                Gender.Male => ApiPaths.MenFootballWorldCupMatches,
                Gender.Female => ApiPaths.WomenFootballWorldCupMatches
            };
            return $"{urlBasedOnGender}/country?fifa_code={fifaCode}";
        }
    }
}
