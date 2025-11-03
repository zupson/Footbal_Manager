namespace ClassLibrary.Models
{
    //ovaj model odgovara API: https://worldcup-vua.nullbit.hr/men/matches
    //ovaj model odgovara API: https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code=ENG
    public class Match
    {
        public string Venue { get; set; }
        public string Location { get; set; }
        public int Attendance { get; set; }
        public DateTime DateTime { get; set; }
        public Team AwayTeam { get; set; }
        public Team HomeTeam { get; set; }
        public TeamStatistics AwayTeamStatistics { get; set; }
        public TeamStatistics HomeTeamStatistics { get; set; }
        public string WinnerCode { get; set; }
    }
}
