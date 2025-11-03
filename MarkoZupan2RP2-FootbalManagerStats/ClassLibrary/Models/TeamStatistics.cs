namespace ClassLibrary.Models
{
    //ovaj model odgovara API: https://worldcup-vua.nullbit.hr/men/matches
    public class TeamStatistics
    {
        public int AttemptsOnGoal { get; set; }
        public int Corners { get; set; }
        public int Offsides { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public List<Player> StartingEleven { get; set; }
        public List<Player> Substitutes { get; set; }
    }
}
