using System.Drawing;

namespace ClassLibrary.Models
{
    //ovaj model odgovara API: https://worldcup-vua.nullbit.hr/men/matches
    public class Player
    {
        public string Name { get; set; }
        public int ShirtNumber { get; set; }
        public string Position { get; set; }
        public bool IsCaptain { get; set; }
        public bool IsFavourite { get; set; }//drag&drop igraca u drugi panel koji prikazuje omiljene igrace moras implemenitrati psotavljanje
        public int ScoredGoals { get; set; }
        public int YellowCards { get; set; }
        public string ImagePath { get; set; }
        public string  TeamColor { get; set; }//sluzi da bi uspjeli bindati i da bi svaki team imao svoju boju

        public string CaptainDisplay => IsCaptain ? "C" : "NC";
        public string DisplayImagePath {
            get
            {
                if(!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
                    return ImagePath;
                return "Images/noImage.png";
            }
        }
    }
    
}
